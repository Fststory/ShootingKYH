using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject firePosition;
    // �������� ���÷��� ���п� ���������� �迭�� ������ ���������� �ʾƵ� ��.
    //public GameObject[] firePositions;
    public AudioSource audioSource;
    


    #region �Ѿ� ���� 
    // ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ��� �����ǰ� �ϰ� �ʹ�!
    // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
    // 2. �Ѿ��� �����Ѵ�.
    // 3. ������ �Ѿ��� �ѱ��� �ű��.
    #endregion
    void Start()
    {
        audioSource.volume = 0.2f;
    }

    void Update()
    {        
        // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {
            // 2. �Ѿ��� �����Ѵ�.
            GameObject go = Instantiate(bulletPrefab);

            // 3. ������ �Ѿ��� �ѱ��� �ű��.
            // 3-1. �ѱ��� ���� ������Ʈ ������ ���� �����ϴ� ���
            go.transform.position = firePosition.transform.position;
            go.transform.rotation = firePosition.transform.rotation;
            // 3-2. �ѱ��� �÷��̾��� ��ġ���� ���� 1.5���� ������ �����ϴ� ���
            //go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
            // ���� �ڵ带 �� �ٷ� ����
            //Vector3 firePos = transform.position + new Vector3(0, 1.5f, 0);
            //go.transform.position = firePos;

            // �Ѿ� �߻����� �����Ѵ�.
            audioSource.Play();
            //audioSource.Stop();
            //audioSource.Pause();
        }

        #region �� �� �̻� �Ѿ��� �߻��� ���
        //if (Input.GetMouseButtonDown(0))
        //{
        //    for (int i = 0; i < firePosition.Length; i++)
        //    {
        //        // 2. �Ѿ��� �����Ѵ�.
        //        GameObject go = Instantiate(bulletPrefab);

        //        // 3. ������ �Ѿ��� �ѱ��� �ű��.
        //        go.transform.position = firePosition[i].transform.position;
        //    }
        //}
        #endregion

    }
}
