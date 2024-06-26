using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tails : MonoBehaviour
{   
    // 목표: 타겟을 향해 계속해서 나아간다.
    // 1. 타겟(Game Object)을 설정할 수 있어야 한다.
    // 2. 타겟을 향한 방향을 계산한다.
    // 3. 계산된 방향과 지정된 속력으로 이동한다.

    public GameObject followingObject;
    public float moveSpeed = 0.5f;
    Vector3 dir;


    void Start()
    {
        
    }

    void Update()
    {
        // 목표를 향한 방향
        dir = followingObject.transform.position - transform.position;
        dir.Normalize();
        // 방향: 나 -> 목표물, 속력: moveSpeed, 시간: Time.deltaTime
        // p = p0 + vt

        transform.position += dir * moveSpeed * Time.deltaTime;
        
    }
}
