using UnityEngine;

public class SpurGear : MonoBehaviour
{
    public Animator anim;

    private float rotateSpeed = 0f;
    private bool isOn;

    public void Rotate(bool isOn)
    {
        this.isOn = isOn;
        anim.SetFloat("Speed", isOn ? rotateSpeed : 0f);
    }

    public void ChangeSpeed(float speed)
    {
        this.rotateSpeed += speed;
        this.isOn = true;
        anim.SetFloat("Speed", isOn ? rotateSpeed : 0f);
    }

}
