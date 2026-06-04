using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class AGVAgentController : MonoBehaviour
{
    //열거형
    public enum State
    {
        Patrol = 0,
        Chase
    }

    [Header("상태 및 컴포넌트")]
    public State currentState = State.Patrol;   //현재 AGV의 동작 모드
    public NavMeshAgent agent;
    [SerializeField] private Transform targetTransform; //타겟의 위치 정보

    [Header("정찰 설정")]
    [SerializeField] Transform[] waypoints;     //패트롤 위치 정보들
    private int currentWaypointIndex = 0;       //현재 패트롤 목표

    [Header("감지 센서 설정")]
    [SerializeField] private float scanInterval = 0.3f;     //감지 주기
    [SerializeField] private float updateInterval = 0.2f;   //추적 위치 갱신 주기
    [SerializeField] private float chaseDuration = 3f;      //추적 유지 시간
    [SerializeField] private float detectingRange = 10f;    //감지 거리
    [Range(0f, 360f)]
    [SerializeField] float viewAngle = 120f;                //감지 시야각(정면 기준 양옆으로 120도)
    [SerializeField] LayerMask targetLayer;                 //타겟의 레이어.
    [SerializeField] LayerMask obstacleLayer;               //장애물의 레이어.
    [SerializeField] Transform sensorPosition;

    private float nextScanTime;
    private float nextUpdateTime;
    private float chaseExpireTime;
    private Vector3 focusPosition;
    private bool seeTarget;

    private void Start()
    {
        //게임오브젝트 안에 있는 NavMeshAgent 불러와 적용.
        agent = GetComponent<NavMeshAgent>();
        if (sensorPosition == null)
            sensorPosition = transform;

        if (waypoints.Length > 0)
            MoveToNextWayPoint();

    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Patrol:
                UpdatePatrolBehaviour();
                break;
            case State.Chase:
                UpdateChaseBehaviour();
                break;
        }
    }
    private void MoveToNextWayPoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[currentWaypointIndex].position);
    }

    private void UpdatePatrolBehaviour()
    {
        if (nextScanTime < Time.time)
        {
            nextScanTime = Time.time + scanInterval;
            if (seeTarget = CheckForTargetWithFOV())
            {
                currentState = State.Chase;
                chaseExpireTime = Time.time + chaseDuration;
                return;
            }
        }

        if (waypoints.Length == 0) return;

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
                currentWaypointIndex = 0;

            MoveToNextWayPoint();
        }
    }
    private void UpdateChaseBehaviour()
    {
        if (nextUpdateTime < Time.time && targetTransform != null)
        {
            nextUpdateTime = Time.time + updateInterval;
            agent.SetDestination(targetTransform.position);

            if (seeTarget = CheckForTargetWithFOV(true))
            {
                chaseExpireTime = Time.time + chaseDuration;
            }
        }

        if (chaseExpireTime < Time.time)
        {
            targetTransform = null;
            currentState = State.Patrol;
            MoveToNextWayPoint();
        }
    }

    private bool CheckForTargetWithFOV(bool chaseMode = false)
    {
        if (chaseMode)
        {
            //AGV 위치에서 타겟 위치를 바라보는 방향 벡터 구하기
            Vector3 directionToTarget = (targetTransform.position - sensorPosition.position).normalized;
            //타겟과의 실제 거리를 계산
            float distanceToTarget = Vector3.Distance(sensorPosition.position, targetTransform.position);

            if (Physics.Raycast(sensorPosition.position, directionToTarget, out RaycastHit hit, distanceToTarget, obstacleLayer))
            {
                focusPosition = hit.point;
                return false;
            }
            else
            {
                //장애물 레이어에 부딪히지 않았으면 시야가 확보된 상태.
                return true;
            }
        }
        else
        {
            //센서 위치 주변 감지 거리 크기의 구형태 안에 타겟이 있는 물리 검사.
            Collider[] hitColliders = Physics.OverlapSphere(sensorPosition.position, detectingRange, targetLayer);

            if (hitColliders.Length > 0)
            {
                Transform target = hitColliders[0].transform;

                Vector3 directionToTarget = (target.position - sensorPosition.position).normalized;
                //AGV의 정면 방향과 타겟의 있는 방향 사이의 각도 계산.
                float angleBetweenTargetAndAGV = Vector3.Angle(transform.forward, directionToTarget);

                if (angleBetweenTargetAndAGV < viewAngle / 2f)
                {
                    //타겟과의 실제 거리 계산
                    float distanceToTarget = Vector3.Distance(sensorPosition.position, directionToTarget);

                    if (!Physics.Raycast(sensorPosition.position, directionToTarget, distanceToTarget, obstacleLayer))
                    {
                        //부딪히지 않은 상태, 시야 확보 상태
                        targetTransform = hitColliders[0].transform;
                        return true;
                    }
                    else
                    {
                        targetTransform = null;
                    }
                }
            }

            return false;
        }
    }


    //씬뷰에서 AGV의 탐지를 시각화하기 위한 함수
    private void OnDrawGizmos()
    {
        if (sensorPosition == null)
            sensorPosition = transform;

        //시야각 시각화하기
        Vector3 leftBoundary = Quaternion.Euler(0f, -viewAngle / 2f, 0f) * transform.forward;
        Vector3 rightBoundary = Quaternion.Euler(0f, viewAngle / 2f, 0f) * transform.forward;

        Handles.color = Color.white;
        //원형 디스크 그리기
        Handles.DrawWireDisc(sensorPosition.position, Vector3.up, detectingRange);
        if (currentState == State.Patrol)
        {
            Handles.color = Color.yellow;
            Gizmos.color = Color.yellow;
        }
        else if (currentState == State.Chase)
        {
            Handles.color = Color.red;
            Gizmos.color = Color.red;
            Handles.DrawLine(sensorPosition.position, seeTarget ? targetTransform.position : focusPosition);
        }

        //선 그리기
        Gizmos.DrawLine(sensorPosition.position, sensorPosition.position + leftBoundary * detectingRange);
        Gizmos.DrawLine(sensorPosition.position, sensorPosition.position + rightBoundary * detectingRange);
    }


}

