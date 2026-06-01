using UnityEngine;

public class Leg : Machine
{
    public Transform[] positions;
    public float speed = 1f;
    public int destination;
    public override void Run()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[destination].position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, positions[destination].position) < 0.01f)
        {
            destination += 1;
            if (destination >= positions.Length)
                destination = 0;
        }
    }
}
