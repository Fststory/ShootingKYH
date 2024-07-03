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
    //public GameObject explosionPrefab;

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

        //print("읽은 값: " + GameManager.gm.BestScore);
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

            // 최고 점수를 저장한다.
            PlayerPrefs.SetInt("BestScore", GameManager.gm.BestScore);

            // 게임 오버 UI를 활성화한다.
            GameManager.gm.ShowGameOverUI();
        }
        // 나도 제거한다.
        Destroy(gameObject);

        //PlayerMove player = other.gameObject.GetComponent<PlayerMove>();
        //if (player != null)
        //{
        //    Destroy(other.gameObject);
        //}
        //Destroy(gameObject);
    }

    // 삭제되는 순간에 호출되는 이벤트 함수
    //private void OnDestroy()
    //{
    //    // 폭발 효과 오브젝트를 나의 위치에 생성한다.
    //    GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
    //    ParticleSystem fx = explosion.GetComponent<ParticleSystem>();
    //    fx.Play();
    //}
}
