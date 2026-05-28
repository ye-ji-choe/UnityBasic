using Unity.Mathematics;
using UnityEngine;

public class Variables : MonoBehaviour
{
    //Integer 정수 타입 : 딱 떨어지는 수
    [SerializeField]private sbyte sbyteValue; //-128 ~ 127
    [SerializeField]private short shortValue; //6만 ~ -6만
    [SerializeField]private int intValue; //21억 ~ -21억
    [SerializeField]private int resultValue;
    [SerializeField]private long longValue; //900조 ~ -900조

    //실수 타입 : 소수점이 포함된 타입
    public float floatValue;
    public float fResultValue;
    public double doubleValue;
    public double doubleValue2;
    

    //참, 거짓
    public bool boolValue;

    public string stringValue = "나는 문자열이야.";
    public string stringValue2 = "111";

    //활성화될 때마다 한번만 호출
    private void OnEnable()
    {
        Debug.Log("활성화됨");
    }

    //비활성화될 때마다 한번만 호출
    private void OnDisable()
    {
        Debug.Log("비활성화됨");
    }

    //처음 시작 시 한번만
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intValue = intValue + intValue;
        if(intValue == 2)
        {
            Debug.Log("intValue는 2가 맞아");
        }
        else
        {
            Debug.Log("intValue는 2가 아니야");
        }

        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;
        fResultValue += floatValue;

        if (fResultValue > 1f)
        {
            Debug.Log($"fResultValue는 1보다 커 => {fResultValue:F7}");

        }
        else
        {
            Debug.Log($"fResultValue는 1보다 작아 => {fResultValue:F7}");
        }

        if (boolValue == true)
        {

            Debug.Log($"boolValue는 참이다");
        }
        else
        {
            Debug.Log($"boolValue는 거짓이다");
        }

        if(long.TryParse(stringValue2, out long result))
        {
            longValue = result;
        }

        intValue = (int)longValue;

    }

    //켜져 있는 동안 한번씩 계속
    // Update is called once per frame
    void Update()
    {
        
        resultValue += intValue;
        stringValue = $"현재 ResultValue값은 {resultValue}입니다.({intValue})";
        //stringValue = resultValue.ToString();

    }

    public bool Jump()
    {
        return true;
    }
}
