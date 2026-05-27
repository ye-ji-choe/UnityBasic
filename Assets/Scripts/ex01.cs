using UnityEngine;

public class ex01 : MonoBehaviour
{
    //public Vector3 pos1;
    //public Vector3 pos2;
    //public Vector3 pos3;
    //public Vector3 pos4;
    //배열
    public Transform[] positions;
    public float speed = 3.0f;
    //public float arriveDistance;
    //public bool arrive = false;
    //public bool arrive2 = false;
    public int destination;


    private void Start()
    {
        //transform.position = Vector3.MoveTowards(transform.position, pos1, speed *Time.deltaTime);


    }
    private void Update()
    {
        //if((arrive == true) && (arrive2 == false))
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos2, speed * Time.deltaTime);
        //    arriveDistance = Vector3.Distance(transform.position, pos2);
        //    if (arriveDistance < 0.01f)
        //    {
        //        arrive2 = true;

        //    }
        //}
        //else if ((arrive == true) && (arrive2 = true) )
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos3, speed * Time.deltaTime);
        //    arriveDistance = Vector3.Distance(transform.position, pos3);
        //    if (arriveDistance < 0.01f)
        //    {
        //        arrive = false;
        //    }
        //}
        //else if ((arrive == false) && (arrive2 == false))
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos1, speed * Time.deltaTime);
        //    arriveDistance = Vector3.Distance(transform.position, pos1);
        //    if (arriveDistance < 0.01f)
        //    {
        //        arrive = true;
        //    }
        //}
        //else if ((arrive == false) && (arrive2 == true))
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pos4, speed * Time.deltaTime);
        //    arriveDistance = Vector3.Distance(transform.position, pos4);
        //    if (arriveDistance < 0.01f)
        //    {
        //        arrive2 = false;
        //    }
        //}

        transform.position = Vector3.MoveTowards(transform.position, positions[destination].position, speed * Time.deltaTime);
        if(Vector3.Distance(transform.position, positions[destination].position) < 0.01f)
        {
            destination += 1;
            if(destination >= positions.Length)
            {
                destination = 0;
            }
        }
    }
}
