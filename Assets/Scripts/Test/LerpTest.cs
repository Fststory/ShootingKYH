using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public float percent = 0;
    public Transform startPos;
    public Transform endPos;

    void Start()
    {
        
    }

    void Update()
    {
        percent += Time.deltaTime*0.5f;

        Vector3 result = Vector3.Lerp(startPos.position, endPos.position, percent);
        transform.position = result;
    }
}
