using UnityEngine;
using UnityEngine.EventSystems;

public class ClickReactor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    //메쉬렌더러 변수
    public MeshRenderer meshRenderer;

    private void Start()
    {
        if(meshRenderer == null)
        {
            meshRenderer = GetComponent<MeshRenderer>();
        }
        PhysicsRaycaster ray = Camera.main.gameObject.GetComponent<PhysicsRaycaster>();
        if(ray == null)
        {
            Camera.main.gameObject.AddComponent<PhysicsRaycaster>();
        }

        if(EventSystem.current == null)
        {
            GameObject go = new GameObject("EventSystem");
            go.AddComponent<EventSystem>();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //마우스 왼쪽 버튼을 누르면 호출
        //메쉬렌더러를 비활성화
        meshRenderer.enabled = false;


    }

    public void OnPointerUp(PointerEventData eventData)
    {
        //마우스 왼쪽 버튼을 떼면 호출
        //메쉬렌더러를 활성화
        meshRenderer.enabled = true;
    }

  
}
