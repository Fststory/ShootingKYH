using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        // 부딪힌 대상을 모두 파괴한다. 단, 플레이어는 제외한다.
        if(other.gameObject.tag != "Bullet")
        {
            Destroy(other.gameObject);
        }
    }
}
