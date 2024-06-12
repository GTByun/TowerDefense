using System.Collections.Generic;
using UnityEngine;

public class ChainBullet : MonoBehaviour
{
    float speed;
    float damage;
    int cushion;
    float chainRange;
    float damageReduce;
    GameObject target;
    Vector3 pos;
    Vector3 rot;
    List<GameObject> hitE;

    public void init(float speed, float damage, int cushion, float chainRange, float damageReduce)
    {
        this.speed = speed;
        this.damage = damage;
        this.cushion = cushion;
        this.chainRange = chainRange;
        this.damageReduce = damageReduce;
    }
    public void setTransform(Vector3 pos, Vector3 rot)
    {
        this.pos = pos;
        this.rot = rot;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    private void OnEnable()
    {
        hitE = new List<GameObject>();
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
    }
    void Update()
    {
        if(target != null) // 타겟이 설정되었는지 확인
        {
            if (!target.activeSelf)
            {
                target = null;
            }
            else 
            {
                Vector2 direction = (target.transform.position - transform.position).normalized; // 타겟 방향 계산
                transform.up = direction; // 총알이 타겟 방향으로 회전
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime); // 회전된 방향으로 이동
    }

    GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = chainRange * GameManager.instance.modular + (GameManager.instance.modular / 2);
        List<GameObject> e = EnemySpawner.enemies;
        for (int i = 0; i < e.Count; i++)
        {
            if (!hitE.Contains(e[i])) 
            {
                float distance = Vector3.Distance(transform.position, e[i].transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = e[i];
                    //return closestEnemy;
                }
            }            
        }
        return closestEnemy;
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
        if (collision.CompareTag("Enemy"))
        {
            cushion--;
            if (cushion <= 0) 
            { 
                gameObject.SetActive(false);
            }
            hitE.Add(collision.gameObject);
            target = FindClosestEnemy();
            if (collision.gameObject.TryGetComponent(out Enemy enemy))
            {
                enemy.Hit(damage);
            }
            damage *= damageReduce;
            speed *= damageReduce;
        }
    }
}
