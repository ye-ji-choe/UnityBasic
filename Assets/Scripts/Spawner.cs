using UnityEngine;
using UnityEngine.EventSystems;

public class Spawner : MonoBehaviour
{


    public GameObject prefab;
    public float power = 100;
    public void OnAttack()
    {
        if(EventSystem.current.IsPointerOverGameObject())
            return;
        
        //동적 생성
        GameObject go = Instantiate<GameObject>(prefab, transform.position, transform.rotation);
        go.GetComponent<Rigidbody>().AddForce(transform.forward * power);
    }
}
