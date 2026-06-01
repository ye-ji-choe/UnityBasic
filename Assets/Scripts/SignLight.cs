using UnityEngine;

public class SignLight : Machine
{
    public MeshRenderer mr;
    public float duration = 1f;
    public bool isOn = false;

    private float remains = 0f;

    public override void Run()
    {
        remains -= Time.deltaTime;
        if (remains < 0f)
        {
            remains = duration;
            isOn = !isOn;
            if (isOn)
                mr.material.EnableKeyword("_EMISSION");
            else
                mr.material.DisableKeyword("_EMISSION");
        }
    }
}
