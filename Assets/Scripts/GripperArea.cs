using System.Collections.Generic;
using UnityEngine;


public class GripperArea : MonoBehaviour
{

    
    public List<Collider> triggerList = new List<Collider>();
    private void OnTriggerEnter(Collider other)
    {
        //트리거 리스트에 트리거된 콜라이더 추가
        triggerList.Add(other);
    }

    private void OnTriggerExit(Collider other)
    {
        //트리거 리스트에 나간 콜라이더 제거
        triggerList.Remove(other);
    }
}
