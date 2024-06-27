using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public GameObject player;


    // ����ڰ� ���콺 ���� ��ư�� ������ �Ѿ��� �ѱ��� �����ǰ� �ϰ� �ʹ�!
    // 1. ����ڰ� ���콺 ���� ��ư�� �������� Ȯ���Ѵ�.
    // 2. �Ѿ��� �����Ѵ�.
    // 3. ������ �Ѿ��� �ѱ��� �ű��.

    public float moveSpeed = 0.1f;

    void Start()
    {
        
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

            // �÷��̾� ���� ������Ʈ�� �پ��ִ� PlayerFire ������Ʈ�� �����´�.
            PlayerFire playerFire = player.GetComponent<PlayerFire>();

            // PlayerFire ������Ʈ�� �ִ� PlayExplotionSound �Լ��� �����Ѵ�.
            playerFire.PlayExplosionSound();
        }

        // ��(this.gameObject)�� �����Ѵ�.
        Destroy(gameObject);
    }
}
