using UnityEngine;

public class BallDetector : MonoBehaviour
{
    public GripperController controller;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
            controller.PickUp();

        if (other.attachedRigidbody.isKinematic)
            return;

        controller.PickUp();
    }
}
