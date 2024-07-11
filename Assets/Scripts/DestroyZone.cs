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
            // 이름이 Boss가 아닌 게임오브젝트라면...
            if (other.gameObject.name != "Boss")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
