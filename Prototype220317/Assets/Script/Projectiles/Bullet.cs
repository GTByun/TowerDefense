using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    float speed;
    float damage;
    int penetrate;
    GameObject target;
    Vector3 pos;
    Vector3 rot;
    bool collisionLock;

    public void init(float speed, float damage, int penetrate)
    {
        this.speed = speed;
        this.damage = damage;
        this.penetrate = penetrate;
    }
    public void setTransform(Vector3 pos, Vector3 rot)
    {
        this.pos = pos;
        this.rot =rot;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    private void OnEnable()
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
        collisionLock = false;
    }
    void Update()
    {        
        if (target != null&&target.activeSelf) // Ÿ���� �����Ǿ����� Ȯ��
        {
            Vector2 direction = (target.transform.position - transform.position).normalized; // Ÿ�� ���� ���
            transform.up = direction; // �Ѿ��� Ÿ�� �������� ȸ��
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime); // ȸ���� �������� �̵�
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GameArea"))
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && !collisionLock)
        {
            gameObject.SetActive(false);
            collision.gameObject.GetComponent<Enemy>().Hit(damage);
            collisionLock = true;
        }
    }
}
