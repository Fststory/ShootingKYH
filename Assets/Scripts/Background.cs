using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    // 머티리얼의 uv offset 값을 조작해서 스크롤 효과를 주고 싶다.
    // 스크롤 방향은 아래쪽으로 한다.
    // p = p0 + vt 방향, 속력

    public float scrollSpeed = 0.2f;

    MeshRenderer mr;

    void Start()
    {
        // MeshRenderer 컴포넌트를 캐싱한다.
        mr = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        if (mr != null)
        {
            // MeshRenderer 컴포넌트에 있는 Materials 배열에서 0번째 머티리얼을 가져온다.
            Material mat = mr.materials[0];

            // 머티리얼의 offset 속성 값의 y축 값을 변경한다.
            mat.mainTextureOffset += new Vector2(0, 1) * scrollSpeed * Time.deltaTime;
        }

    }
}
