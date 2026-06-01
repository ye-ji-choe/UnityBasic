using UnityEngine;

public class BallDetector2_ex04 : MonoBehaviour
{
    public Arm2Controller controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
            controller.PickUp();
        if (other.attachedRigidbody.isKinematic)
            return;

        controller.PickUp();
    }
}
