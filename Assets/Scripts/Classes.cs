using UnityEngine;

public class Classes : MonoBehaviour
{
    public struct MeshStruct
    {
        public int value;
    }
    
    public class MeshClass
    {
        public int value;
    }

    private void Start()
    {
        //구조체 : 값 형식
        MeshStruct s0 = new MeshStruct();
        s0.value = 15;
        MeshStruct s1 = new MeshStruct();
        s1.value = 30;
        Debug.Log($"Before : s0의 값은 {s0.value}, s1의 값은 {s1.value}");
        SwapStruct(s0,s1);
        Debug.Log($"After : s0의 값은 {s0.value}, s1의 값은 {s1.value}d");

        //클래스 : 참조 타입
        MeshClass c0 = new MeshClass();
        c0.value = 100;
        MeshClass c1 = new MeshClass();
        c1.value = 200;
        Debug.Log($"Before : c0의 값은 {c0.value}, c1의 값은 {c1.value}");
        SwapClass(c0, c1);
        Debug.Log($"After : c0의 값은 {c0.value}, c1의 값은 {c1.value}d");
    }

    private void SwapStruct(MeshStruct left, MeshStruct right)
    {
        int temp = left.value;
        left.value = right.value;
        right.value = temp;

    }

    private void SwapClass(MeshClass left, MeshClass right)
    {
        int temp = left.value;
        left.value = right.value;
        right.value = temp;

    }



}
