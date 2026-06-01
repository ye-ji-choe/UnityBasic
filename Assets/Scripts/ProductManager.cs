using UnityEngine;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class ProductManager : MonoBehaviour
{
    [System.Serializable]
    public struct ProductInfo
    {
        public string productName;
        public Vector3 position;
        public Mesh shape;
        public Material material;

        public void MakeProduct()
        {
            //상품 이름으로 된 빈 게임 오브젝트 생성
            GameObject go = new GameObject(productName);
            //게임 오브젝트에 메쉬필터 컴포넌트 추가
            MeshFilter filter = go.AddComponent<MeshFilter>();
            //필터에 상품 형태 적용
            filter.mesh = shape;
            //게임 오브젝트에 메쉬렌더러 추가
            MeshRenderer mr = go.AddComponent<MeshRenderer>();
            //게임 오브젝트 위치 조정
            go.transform.position = position;
            mr.material = material;
        }

        public override string ToString()
        {
            return $"{productName} => 생성 위치는 {position}입니다.";
        }
    }

    public ProductInfo[] infoList;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(var info in infoList)
        {
            Debug.Log(info.ToString());
            info.MakeProduct();
        }
        
        //foreach (ProductInfo info in infoList)
        //{
        //    //상품 이름으로 된 빈 게임 오브젝트 생성
        //    GameObject go = new GameObject(info.productName);
        //    //게임 오브젝트에 메쉬필터 컴포넌트 추가
        //    MeshFilter filter = go.AddComponent<MeshFilter>();
        //    //필터에 상품 형태 적용
        //    filter.mesh = info.shape;
        //    //게임 오브젝트에 메쉬렌더러 추가
        //    MeshRenderer mr = go.AddComponent<MeshRenderer>();
        //    //게임 오브젝트 위치 조정
        //    go.transform.position = info.position;

        //    mr.material = info.material;
        //}
    }

}
