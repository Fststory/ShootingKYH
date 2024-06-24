using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 플레이어를 원하는 방향으로 이동한다.
    // 방향, 속력 = 속도(Vector)

    public float moveSpeed = 0.1f;
    //Vector3 direction;

    // 처음 생성되었을 때 한 번만 실행되는 함수
    void Start()
    {
        //transform.position += Vector3.right;
    }

    // 매 프레임마다 반복해서 실행하는 함수
    void Update()
    {
        //Vector3 direction = new Vector3(1, 1, 0);
        //transform.position += Vector3.right * moveSpeed;
        //transform.position += direction * moveSpeed;

        //print(transform.position);

        // 사용자의 입력 받기
        //float h = Input.GetAxis("Horizontal");
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, v, 0);
        // 벡터의 길이를 무조건 1로 바꾼다.(정규화) <= 대각선으로 이동 시 벡터(속력)의 크기가 커지므로
        direction.Normalize();

        // 이동 공식 : p = p0 + vt
        transform.position += direction * moveSpeed * Time.deltaTime;
        //transform.eulerAngles += direction * moveSpeed * Time.deltaTime;
        //transform.localScale += direction * moveSpeed * Time.deltaTime;

        // 특정 키를 입력했을 때 사용하는 함수(Get, GetDown, GetUp)
        //bool value = Input.GetButton("Horizontal");

        //if (Input.GetKey(KeyCode.F1))
        //{
        //    print("F1 키를 눌렀습니다!");
        //}
    }
}
