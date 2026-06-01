using UnityEngine;

public class BallDetector_ex04 : MonoBehaviour
{
    public Arm1Controller controller;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"{other.name}");
        if (other.tag != "Ball")
            return;

        if (other.attachedRigidbody.isKinematic)
            return;

        controller.PickUp();
    }
}