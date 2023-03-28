using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortingLayerInMeshRenderer : MonoBehaviour
{
    // TextMesh로 만든 커맨드가 다른 오브젝트의 스프라이트에 가려지지 않도록 sortingOrder를 임의로 설정 할 수 있게.
    public int sortingOrder;
    void Start()
    {
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        // 임의로 지정한 sortingOrder를 TextMesh sortingOrder에 할당
        mesh.sortingOrder = sortingOrder;
    }
}
