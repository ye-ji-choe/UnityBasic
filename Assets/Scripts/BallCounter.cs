using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class BallCounter : MonoBehaviour
{
    
    public List<GameObject> triggers = new List<GameObject>();
    public Text countText;

    public void ClearBall()
    {
        foreach(GameObject go in triggers)
        {
            Destroy(go);
        }
        triggers.Clear();
        countText.text = triggers.Count.ToString("D3");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggers.Contains(other.gameObject))
            return;
        
        triggers.Add(other.gameObject);
        countText.text = triggers.Count.ToString("D3");

    }

    private void OnTriggerExit(Collider other)
    {
        if (!triggers.Contains(other.gameObject))
            return;

        triggers.Remove(other.gameObject);
        countText.text = triggers.Count.ToString("D3");

    }
}
