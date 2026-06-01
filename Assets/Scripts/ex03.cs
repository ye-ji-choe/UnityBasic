using System.Collections.Generic;
using UnityEngine;

public class ex03 : MonoBehaviour
{
    //캡슐이 영역 안에 들어오면 큐브 색을 빨간색으로 바꾼다.
    //캡술이 영역 밖으로 나가면 큐브 색을 원래색으로 바꾼다.
    public MeshRenderer meshRenderer;
    public Color onColor = Color.red;
    private Color defaultColor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (meshRenderer == null)
        {
            //찾아서 넣어줘라.
            meshRenderer = GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                defaultColor = meshRenderer.material.color;
            }
        }
        else
        {
            defaultColor = meshRenderer.material.color;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (meshRenderer == null)
            return;

        meshRenderer.material.color = onColor;
    }

    private void OnTriggerExit(Collider other)
    {
        if (meshRenderer == null)
            return;

        meshRenderer.material.color = defaultColor;

    }


}
