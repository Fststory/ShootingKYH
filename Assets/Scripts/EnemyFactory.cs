using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // 지정한 시간이 될 때마다 에너미를 생성한다.
    // 지정 시간, 에너미 프리펩, 경과된 시간

    public GameObject enemyPrefab;
    public float delayTime = 2.0f;

    float currentTime = 0;
    float printTime = 1.0f;
    int timeCount = 3;
    bool isTimerStart = true;

    void Start()
    {
        // Invoke 함수를 이용한 타이머 기능
        // 1회용 타이머
        //Invoke("InvokeTest", 2.5f);

        // 반복 타이머
        //InvokeRepeating("InvokeTest", 3.5f, 1.0f);
        // Invoke 함수는 매개변수가 없는 함수만 사용 가능하다!
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > delayTime)
        {
            // 에너미를 생성한다.
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            

            // 경과 시간을 다시 0으로 초기화한다.
            currentTime = 0;
        }

        #region MyAnswer 3초 카운트 기능 구현 연습
        // 3초 ~ 0초까지 남은 시간을 프린트한다.
        // 남은 시간(지정 시간 경과 시간), 종료 조건

        //float time = delayTime - Time.deltaTime;        // 매 프레임마다 지정 시간(delayTime)에서 경과 시간(Time.deltaTime)을 빼준다.
        //if (0 <= time && time <= delayTime)
        //{
        //    if (2 < time && time <= 3)        // 3초에 3 출력
        //    {
        //        print(3);
        //    }
        //    if (1 < time && time <= 2)        // 2초에 2 출력
        //    {
        //        print(2);
        //    }
        //    if (0 < time && time <= 1)        // 1초에 1 출력
        //    {
        //        print(1);
        //    }
        //    if (time < 0)                     // 0이 되면 start!! 출력
        //    {
        //        print("start!!");
        //    }
        //}
        #endregion

        #region Teacher answer 3초 카운트 기능 구현 연습
        // 3초부터 카운트 다운을 시작한다.
        // 단, 매 1초마다 남은 시간을 출력한다.
        // 마지막에는 "Start"로 출력한다.
        // 남은 시간이 0초가 되면 카운트를 중단한다.

        //if (isTimerStart)
        //{
        //    printTime = 3;
        //    StartTimer();
        //}
        #endregion
                

    }
    //void StartTimer()
    //{
    //    currentTime += Time.deltaTime;
    //    if (currentTime > printTime)
    //    {
    //        if (timeCount == 0)
    //        {
    //            print("Start!");
    //            isTimerStart = false;
    //            //currentTime = 0;
    //            //printTime = 3;
    //        }
    //        else
    //        {
    //            print(timeCount);
    //        }
            
    //        timeCount--;
    //        currentTime = 0;
    //    }
    //}

    void InvokeTest()
    {
        print("인보크 기능 실시!");
    }
}
