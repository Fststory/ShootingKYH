using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    float moveSpeed = 0.1f;

    void Start()
    {
        
    }

    void Update()
    {
        // 위로 계속 이동하고 싶다.
        // 방향: 위로, 이동 속력: float, public
        // 이동 공식 : p = p0 + vt , p += vt
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        //transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
    }
}
