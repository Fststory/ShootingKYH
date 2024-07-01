using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject player;

    public GameObject explosionPrefab;

    PlayerFire pFire;

    // ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ��� �����ǰ� �ϰ� �ʹ�!
    // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
    // 2. �Ѿ��� �����Ѵ�.
    // 3. ������ �Ѿ��� �ѱ��� �ű��.

    public float moveSpeed = 0.1f;

    float lifeSpan=3.0f;

    void Start()
    {
        // Player ������Ʈ�� PlayerFire ������Ʈ�� ������ �����Ѵ�.(==ĳ���Ѵ�)
        if(player != null)
        {
            pFire = player.GetComponent<PlayerFire>();
        }
    }

    void Update()
    {
        // ���� ��� �̵��ϰ� �ʹ�.
        // ����: ����, �̵� �ӷ�: float, public
        // �̵� ���� : p = p0 + vt , p += vt
        
        // ���� ����
        Vector3 worldDir = Vector3.up;

        // ���� ����(���� ��������)
        Vector3 localDir = transform.up;

        transform.position += localDir * moveSpeed * Time.deltaTime;
        //transform.position += new Vector3(0, 1, 0) * moveSpeed * Time.deltaTime;
    
        lifeSpan -= Time.deltaTime;
        if (lifeSpan < 0)
        {
            if (pFire.useObjectPool || pFire.useArray)
            {
                Reload();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }



    // ������ �浹�� �߻����� �� ����Ǵ� �̺�Ʈ �Լ�
    private void OnCollisionEnter(Collision collision)
    {
        // �浹�� ���� ������Ʈ�� �����Ѵ�.
        Destroy(collision.gameObject);

        // ��(this.gameObject)�� �����Ѵ�.
        Destroy(gameObject);
    }

    // ������ �浹 ���� ������ ���� �� ����Ǵ� �̺�Ʈ �Լ�
    private void OnTriggerEnter(Collider col)
    {
        // �浹�� ���� ������Ʈ�� �����Ѵ�.
        EnemyMove enemy = col.gameObject.GetComponent<EnemyMove>();
        
        // enemy ������ ���� �ִٸ�...
        if(enemy != null)
        {
            Destroy(col.gameObject);

            // ���� ����Ʈ �������� ���ʹ̰� �ִ� �ڸ��� �����Ѵ�.
            GameObject fx = Instantiate(explosionPrefab,col.transform.position,col.transform.rotation);

            // ������ ���� ����Ʈ ������Ʈ���� ��ƼŬ �ý��� ������Ʈ�� �����ͼ� �÷����Ѵ�.
            ParticleSystem ps = fx.GetComponent<ParticleSystem>();
            ps.Play();

            // �÷��̾� ���� ������Ʈ�� �پ��ִ� PlayerFire ������Ʈ�� �����´�.
            PlayerFire playerFire = player.GetComponent<PlayerFire>();

            // PlayerFire ������Ʈ�� �ִ� PlayExplotionSound �Լ��� �����Ѵ�.
            playerFire.PlayExplosionSound();
        }

        
        if (pFire.useObjectPool || pFire.useArray)
        {
            Reload();
        }
        else
        {
            // ��(this.gameObject)�� �����Ѵ�.
            Destroy(gameObject);
        }
    }

    public void Reload()
    {
        if (pFire.useObjectPool)
        {
        // �ڱ� �ڽ�(gameObject)�� PlayerFire�� List bullets�� �߰��ϰ� ��Ȱ��ȭ �Ѵ�.
        pFire.bullets.Add(gameObject);
        lifeSpan = 3.0f;
        gameObject.SetActive(false);
        }
        else if (pFire.useArray)
        {
            // bulletArray �迭�� �� ���� �ִ� ���� ã�´�.
            for(int i = 0; i < pFire.bulletArray.Length; i++)
            {
                // ����, i��° �ε����� ���� null�̶��...
                if (pFire.bulletArray[i] == null)
                {
                    pFire.bulletArray[i] = gameObject;
                    gameObject.SetActive(false);
                    lifeSpan = 3.0f;
                    break;
                }
            }
        }
    }
}
