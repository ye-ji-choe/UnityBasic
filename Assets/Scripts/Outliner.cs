using UnityEngine;
using UnityEngine.EventSystems;

public class Outliner : MonoBehaviour, IPointerClickHandler
{
    //렌더링할 게임오브젝트
    public GameObject[] renderObjects;

    private int layer;
    private int outlineLayer;
    private bool isOnOutline;


    private void Start()
    {
        //시작시 레이어 저장
        layer = gameObject.layer;
        outlineLayer = LayerMask.NameToLayer("Outline");

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //클릭할 때마다 아웃라인을 표시했다 표시x 반전
        isOnOutline = !isOnOutline;
        foreach(GameObject go in renderObjects)
        {
            go.layer = isOnOutline ? outlineLayer : layer;
        }
    }
}
