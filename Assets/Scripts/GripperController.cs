using UnityEngine;

public class GripperController : MonoBehaviour
{
    public Animator anim;
    public GripperArea area;

    private void Start()
    {
        //anim 변수가 비어있으면 찾아서 넣어라.
        if(anim == null)
        {
            anim = GetComponent<Animator>();
        }
    }

    public void TurnOn(bool isOn)
    {
        //애니메이터가 변수에 참조되어 있지 않으면 Return
        if (anim == null)
            return;
        //bool타입 파라미터에 참, 거짓데이터 적용
        anim.SetBool("IsOn", isOn);
    }

    public void PickUp()
    {
        if (anim == null)
            return;
        //Trigger타입 파라미터 발동
        anim.SetTrigger("PickUp");

    }

    public void Pick()
    {
        if (area.triggerList.Count == 0)
            return;
        foreach(Collider c in area.triggerList)
        {
            c.attachedRigidbody.isKinematic = true;
            c.transform.SetParent(area.transform);
        }
    }

    public void Drop()
    {
        foreach(Collider c in area.triggerList)
        {
            c.attachedRigidbody.isKinematic = false;
            c.transform.SetParent(null);
        }
    }
}
