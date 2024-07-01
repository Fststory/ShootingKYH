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

    public List<GameObject> bullets = new List<GameObject>();
    public int bulletCount = 10;
    public bool useObjectPool = false;

    public GameObject[] bulletArray;
    public bool useArray = false;

    public AudioClip[] sounds;

    AudioSource audioSource;


    #region �Ѿ� ���� 
    // ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ��� �����ǰ� �ϰ� �ʹ�!
    // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
    // 2. �Ѿ��� �����Ѵ�.
    // 3. ������ �Ѿ��� �ѱ��� �ű��.
    #endregion
    void Start()
    {
        // AudioSource ������Ʈ�� �������� ���
        audioSource = transform.GetComponent<AudioSource>();

        if (useObjectPool)
        {
            // �Ѿ� 10���� �̸� ���� bullets ����Ʈ�� �߰��Ѵ�.
            for(int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bullets.Add(go);
                go.GetComponent<BulletMove>().player = gameObject;

                // ������ �Ѿ��� ��Ȱ��ȭ�Ѵ�.
                go.SetActive(false);
            }
        }

        if (useArray)
        {
            // �迭 ������ ũ�⸦ ������ ������ Ȯ���Ѵ�.
            bulletArray = new GameObject[bulletCount];

            // �迭�� �� ��ȣ�� �Ѿ� �ν��Ͻ��� �����ؼ� �Ҵ��Ѵ�.
            for(int i = 0; i < bulletCount; i++)
            {
                GameObject go = Instantiate(bulletPrefab);
                bulletArray[i] = go;
                go.SetActive(false);
                go.GetComponent<BulletMove>().player = gameObject;
            }
        }
    }

    void Update()
    {        
        // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
        if (Input.GetMouseButtonDown(0))
        {
            if (useArray)
            {
                // ������Ʈ Ǯ ���(�迭)���� �Ѿ� ���
                ObjectPoolArrayType();
            }
            else if (useObjectPool)
            {
                // ������Ʈ Ǯ ���(����Ʈ)���� �Ѿ� ���
                ObjectPoolType();
            }

            if(!useObjectPool && !useArray)
            {
                // �⺻ ����� �Ѿ��� ����
                InstantiateType();
            }

            // �Ѿ� �߻����� �����Ѵ�.
            audioSource.clip = sounds[0];
            audioSource.volume = 0.2f;
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

    void InstantiateType()
    {
        // 2.�Ѿ��� �����Ѵ�.
        GameObject go = Instantiate(bulletPrefab);

        //3.������ �Ѿ��� �ѱ��� �ű��.
        // 3 - 1.�ѱ��� ���� ������Ʈ ������ ���� �����ϴ� ���
        go.transform.position = firePosition.transform.position;
        go.transform.rotation = firePosition.transform.rotation;

        // 3-2. �ѱ��� �÷��̾��� ��ġ���� ���� 1.5���� ������ �����ϴ� ���
        go.transform.position = transform.position + new Vector3(0, 1.5f, 0);
        //���� �ڵ带 �� �ٷ� ����
        Vector3 firePos = transform.position + new Vector3(0, 1.5f, 0);
        go.transform.position = firePos;

        // 4. ������ �Ѿ��� BulletMove ������Ʈ�� �ִ� Player ������ �ڱ� �ڽ��� �ִ´�.
        //go.GetComponent<BulletMove>().player = gameObject;
    }

    void ObjectPoolType()
    {
        // 0�� �ε����� �Ѿ� ������Ʈ�� Ȱ��ȭ�Ѵ�.
        bullets[0].SetActive(true);

        // Ȱ��ȭ�� �Ѿ��� ��ġ �� ȸ���� �ѱ��� ��ġ��Ų��.
        bullets[0].transform.position = firePosition.transform.position;
        bullets[0].transform.rotation = firePosition.transform.rotation;

        // 0�� �ε����� �Ѿ� ������Ʈ�� źâ ����Ʈ���� �����Ѵ�.
        bullets.RemoveAt(0);
    }

    void ObjectPoolArrayType()
    {
        // i�� ���� ���� ��ȣ�� �����ϵ��� �Ѵ�.
        //i = (i + 1) % bulletArray.Length;
        for(int i = 0; i < bulletArray.Length; i++)
        {
            if (bulletArray[i] != null)
            {
                // �ش� �ε����� �Ѿ� ������Ʈ�� ��Ȱ��ȭ ���������� Ȯ���Ѵ�.
                if (!bulletArray[i].activeInHierarchy)
                {
                    // i ���� ���� �ش��ϴ� �ε����� ������Ʈ�� Ȱ��ȭ�Ѵ�.
                    bulletArray[i].SetActive(true);

                    // Ȱ��ȭ�� �Ѿ��� ��ġ �� ȸ�� ���� �ѱ��� ��ġ��Ų��.
                    bulletArray[i].transform.position = firePosition.transform.position;
                    bulletArray[i].transform.rotation = firePosition.transform.rotation;

                    // �迭���� �ش� �Ѿ��� �����Ѵ�.
                    bulletArray[i] = null;
                    break;
                }
            }
        }
    }


    // ���� ȿ������ �÷����ϴ� �Լ�
    public void PlayExplosionSound()
    {
        audioSource.clip = sounds[1];
        audioSource.volume = 1.0f;
        audioSource.Play();
    }
}
