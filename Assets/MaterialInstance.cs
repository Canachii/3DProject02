using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MaterialInstance : MonoBehaviour
{
    // 머티리얼을 적용할 메쉬 랜더러
    private MeshRenderer m_MeshRenderer;

    // 변경할 색
    [SerializeField] private Color _color;
    
    // Start is called before the first frame update
    void Start()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
        // 기능을 가져옵니다.
        m_MeshRenderer.material = Instantiate(m_MeshRenderer.material);
        // 가져온 머티리얼을 Instantiate로 생성합니다.(복제)
        m_MeshRenderer.material.color = _color;
        // 머티리얼의 색을 설정한 색으로 변경합니다.
    }
}
