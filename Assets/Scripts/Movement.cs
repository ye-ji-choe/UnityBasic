using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public Rigidbody rb;
    
    //이동할 방향
    public Vector2 direction;
    public float moveSpeed = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputValue value)
    {
        direction = value.Get<Vector2>();
        Debug.Log($"방향값 => {direction}");
    }

    private void FixedUpdate()
    {
        Vector3 move;
        move.x = direction.x;
        move.y = 0;
        move.z = direction.y;
        rb.MovePosition(rb.position + move * moveSpeed * Time.deltaTime);
    }
}
