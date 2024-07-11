using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    // ������ �ð��� �� ������ ���ʹ̸� �����Ѵ�.
    // ���� �ð�, ���ʹ� ������, ����� �ð�

    public GameObject enemyPrefab;
    public float delayTime = 2.0f;

    float currentTime = 0;
    float printTime = 1.0f;
    int timeCount = 3;
    bool isTimerStart = true;

    void Start()
    {
        // Invoke �Լ��� �̿��� Ÿ�̸� ���
        // 1ȸ�� Ÿ�̸�
        //Invoke("InvokeTest", 2.5f);

        // �ݺ� Ÿ�̸�
        //InvokeRepeating("InvokeTest", 3.5f, 1.0f);
        // Invoke �Լ��� �Ű������� ���� �Լ��� ��� �����ϴ�!
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > delayTime)
        {
            // ���ʹ̸� �����Ѵ�.
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.transform.position = transform.position;
            enemy.transform.rotation = transform.rotation;
            

            // ��� �ð��� �ٽ� 0���� �ʱ�ȭ�Ѵ�.
            currentTime = 0;
        }

        #region MyAnswer 3�� ī��Ʈ ��� ���� ����
        // 3�� ~ 0�ʱ��� ���� �ð��� ����Ʈ�Ѵ�.
        // ���� �ð�(���� �ð� ��� �ð�), ���� ����

        //float time = delayTime - Time.deltaTime;        // �� �����Ӹ��� ���� �ð�(delayTime)���� ��� �ð�(Time.deltaTime)�� ���ش�.
        //if (0 <= time && time <= delayTime)
        //{
        //    if (2 < time && time <= 3)        // 3�ʿ� 3 ���
        //    {
        //        print(3);
        //    }
        //    if (1 < time && time <= 2)        // 2�ʿ� 2 ���
        //    {
        //        print(2);
        //    }
        //    if (0 < time && time <= 1)        // 1�ʿ� 1 ���
        //    {
        //        print(1);
        //    }
        //    if (time < 0)                     // 0�� �Ǹ� start!! ���
        //    {
        //        print("start!!");
        //    }
        //}
        #endregion

        #region Teacher answer 3�� ī��Ʈ ��� ���� ����
        // 3�ʺ��� ī��Ʈ �ٿ��� �����Ѵ�.
        // ��, �� 1�ʸ��� ���� �ð��� ����Ѵ�.
        // ���������� "Start"�� ����Ѵ�.
        // ���� �ð��� 0�ʰ� �Ǹ� ī��Ʈ�� �ߴ��Ѵ�.

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
        print("�κ�ũ ��� �ǽ�!");
    }
}
