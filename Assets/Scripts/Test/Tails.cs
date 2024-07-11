using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tails : MonoBehaviour
{   
    // ��ǥ: Ÿ���� ���� ����ؼ� ���ư���.
    // 1. Ÿ��(Game Object)�� ������ �� �־�� �Ѵ�.
    // 2. Ÿ���� ���� ������ ����Ѵ�.
    // 3. ���� ����� ������ �ӷ����� �̵��Ѵ�.

    public GameObject followingObject;
    public float moveSpeed = 0.5f;
    Vector3 dir;


    void Start()
    {
        
    }

    void Update()
    {
        // ��ǥ�� ���� ����
        dir = followingObject.transform.position - transform.position;
        dir.Normalize();
        // ����: �� -> ��ǥ��, �ӷ�: moveSpeed, �ð�: Time.deltaTime
        // p = p0 + vt

        transform.position += dir * moveSpeed * Time.deltaTime;
        
    }
}
