using UnityEngine;

public class Head : Machine
{
    public Vector3 axis = Vector3.up;
    public float rotateSpeed = 90f;

    public override void Run()
    {
        transform.Rotate(axis * rotateSpeed * Time.deltaTime, Space.World);
    }
}
