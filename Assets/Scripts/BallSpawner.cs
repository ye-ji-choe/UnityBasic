using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GripperController controller;
    //동적 생성할 게임오브젝트
    public GameObject ball;
    //생성할 위치 정보
    public Transform spawnPosition;
    //생성 인터벌
    public float interval = 3f;
    //다음 생성할 시간
    private float waitTime = 0f;



    void Update()
    {
        //볼이 없으면 무시
        if (ball == null)
            return;

        //컨트롤러가 꺼져 있으면 무시
        if (controller.isOn == false)
            return;

        //다음 생성시간이 넘어갔으면 생성
        if (waitTime < Time.time)
        {
            waitTime = Time.time + interval;
            Instantiate<GameObject>(ball, spawnPosition.position, spawnPosition.rotation);
        }
    }
}

