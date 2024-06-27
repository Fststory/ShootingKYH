using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // 지정된 확률에 따라 아래로 또는 플레이어 방향으로 이동 방향을 결정한다.
    // 확률에 따라 추첨한다. -> 확률 변수, 랜덤 값

    // 필용 요소: 방향, 속력(크기)
    public float moveSpeed = 0.5f;
    public GameObject player;
    public int downRate = 35;

    Vector3 dir;
    //AudioSource explosionSound;

    void Start()
    {
        // 1. 현재 씬에서 "Player"라는 이름으로 게임 오브젝트를 찾는다.
        //player = GameObject.Find("Player");

        // 2. 현재 씬에서 PlayerMove 컴포넌트를 가지고 있는 오브젝트를 찾는다.
        //PlayerMove playerComp = FindObjectOfType<PlayerMove>();
        //player = playerComp.gameObject;

        // 3. 게임 오브젝트에 설정된 태그 이름으로 게임 오브젝트를 찾는다.
        player = GameObject.FindGameObjectWithTag("MyPlayer");

        // 랜덤한 숫자를 하나 뽑는다.
        int myNumber = Random.Range(0, 100);

        // 만일, 뽑은 숫자가 downRate 값보다 작으면, 방향을 아래로 설정한다.
        if(myNumber < downRate)
        {
            dir = Vector3.down;
        }
        // 그렇지 않다면, 방향을 플레이어 쪽으로 설정한다.
        else
        {
            // 만일, 플레이어가 있다면...
            if (player != null)
            {
                // 플레이어를 향한 방향
                dir = player.transform.position - transform.position;
                dir.Normalize();
            }
            else
            {
                dir = Vector3.down;
            }
        }

        //// 오디오 컴포넌트를 캐싱한다.
        //explosionSound = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        // 아래 방향(월드 좌표)
        // Vector3 dir = new Vector3(0, -1, 0);

        // p = p0 + vt
        transform.position += dir * moveSpeed * Time.deltaTime;
    }


    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 대상이 플레이어라면...
        if(other.gameObject.name=="Player")
        {
            // 플레이어를 제거하고
            Destroy(other.gameObject);

            // 나도 제거한다.
            Destroy(gameObject);
        }

        //PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
        //if (player != null)
        //{
        //    Destroy(other.gameObject);
        //}
        //Destroy(gameObject);
    }

}
