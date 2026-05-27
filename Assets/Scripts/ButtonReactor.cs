using JetBrains.Annotations;
using UnityEngine;

public class ButtonReactor : MonoBehaviour
{
    public GameObject jumper1;
    public GameObject jumper2;
    public GameObject jumper3;
    public Variables vari;
   
    public void OnJump()
    {
        if (jumper1 != null)
            jumper1.SetActive(true);
        if (jumper2 != null)
            jumper2.SetActive(true);
        if (jumper3 != null)
            jumper3.SetActive(true);
        if (vari != null)
            vari.enabled = true;
        Debug.Log("점프 버튼 눌렀음.");
       
    }

    public void OnOut()
    {
        if (jumper1 != null)
            jumper1.SetActive(false);
        if (jumper2 != null)
            jumper2.SetActive(false);
        if (jumper3 != null)
            jumper3.SetActive(false);
        if (vari != null)
            vari.enabled = false;
        Debug.Log("아웃 버튼 눌렀음.");
    }
}
