using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public int penetrate;
    private Transform target;

    public void init(float speed, float damage, int penetrate)
    {
        this.speed = speed;
        this.damage = damage;
        this.penetrate = penetrate;
    }
    public void setTransform(Vector3 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
    }
    public void SetTarget(Transform target)
    {
        this.target = target;
    }
    void Start()
    {

    }
    void Update()
    {
        if (target != null) // Ÿ���� �����Ǿ����� Ȯ��
        {
            Vector2 direction = (target.position - transform.position).normalized; // Ÿ�� ���� ���
            transform.up = direction; // �Ѿ��� Ÿ�� �������� ȸ��
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime); // ȸ���� �������� �̵�
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(CompareTag("Fire")){ 
            if (collision.CompareTag("Breath"))
            {
                Destroy(gameObject);
            }
        }
        if (collision.CompareTag("GameArea"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hit(damage);
            if (penetrate <= 0) Destroy(gameObject);
            penetrate--;
        }
    }
}
