using UnityEngine;

public class Rotater : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float rotateSpeed = 90f;
    public Transform target = null;

    private float distance = 0f;
    
    void Start()
    {
        if(target != null)
        {
            //목적지 - 현재 위치 => 목적방향과 거리가 결과로 나옴
            Vector3 direction = target.position - transform.position;
            distance = direction.magnitude;
            //목적방향을 향하는 회전값을 구해서 적용
            transform.rotation = Quaternion.LookRotation(direction.normalized, Vector3.up);

        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(axis * rotateSpeed * Time.deltaTime, Space.World);
        if(target != null)
        {
            //바라보고 있는 z축 방향
            transform.position = -transform.forward * distance + target.position; 
        }
        
    }
}
