using UnityEngine;

public class MachineManager : MonoBehaviour
{

    [System.Serializable]

    public abstract class MachinePart
    {
        public string name;

        public abstract void Run();
        
    }

    public class Head : MachinePart
    {
        public override void Run()
        {
            Debug.Log("두리번 거려라");

        }
    }

    public class TwoHead : Head
    {
        public override void Run()
        {
            Debug.Log("왼쪽으로 두리번");
            Debug.Log("오른쪽으로 두리번");

        }
    }

    public class Arm : MachinePart
    {
        public override void Run()
        {
            Debug.Log("두 팔을 휘둘러라");

        }
    }

    public class Leg : MachinePart
    {
        public override void Run()
        {
            Debug.Log("두 다리로 걸어라");

        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Head head = new Head();
        Arm arm = new Arm();
        Leg leg = new Leg();

        MachinePart[] parts = new MachinePart[3];
        parts[0] = new Head();
        parts[1] = new Arm();
        parts[2] = new Leg();
        
        foreach(var part in parts)
        {
            part.Run();
        }

    }
    public Machine[] machines;
    //인터페이스
    private IRobot[] robots;
    private void Update()
    {
        foreach(Machine m in machines)
        {
            m.Run();
        }
        foreach (IRobot r in robots)
        {
            r.Run();
        }

    }


}
