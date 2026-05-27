using UnityEngine;
using UnityEngine.EventSystems;


public class PointerReactor : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public MeshRenderer[] meshRenderers;
    public Color enterColor;
    public Color exitColor;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        foreach(MeshRenderer r in meshRenderers)
        {
            r.material.color = enterColor;
        }

        transform.localScale = Vector3.one * 3f;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //foreach(MeshRenderer r in meshRenderers)
        //{
        //    r.material.color = exitColor;
        //}
        
        //for문 예제
        for(int i = 0; i < meshRenderers.Length; i++)
        {
            meshRenderers[i].material.color = exitColor;
        }
        transform.localScale = Vector3.one;
    }

    void Start()
    {
        foreach(MeshRenderer r in meshRenderers)
        {
            r.material.color = exitColor;
        }
        
    }

}
