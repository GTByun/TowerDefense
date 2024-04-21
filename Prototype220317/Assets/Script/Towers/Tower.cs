using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public ObjectPool pool;

    protected float range;
    protected float speed;
    protected float damage;
    protected int penetrate;

    protected float reloadDelay;
    private float attackTimer;

    protected GameObject target = null;
    protected GameObject[] enemies;
    public Transform enemiesPool;

    protected virtual void Start()
    {
        
    }
    void Awake()
    {
        enemiesPool = GameObject.Find("Enemies").transform;
    }

    void GetEnemies()
    {
        enemies=new GameObject[enemiesPool.childCount];
        for (int i = 0; i < enemiesPool.childCount; i++)
        {
            enemies[i] = enemiesPool.GetChild(i).gameObject;
        }
    }

    protected virtual void Update()
    {
        // 대상이 없으면 새로운 대상을 찾습니다.
        if (target == null||!target.activeSelf)
        {
            target = FindClosestEnemy();
        }
        // 대상이 있으면 일정 시간 간격으로 공격을 수행합니다.
        else if (target != null&&target.activeSelf)
        {
            RotateTowardsTarget();
            attackTimer += Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) < range * GameManager.instance.modular + (GameManager.instance.modular / 2))
            {
                if (attackTimer >= 1f / reloadDelay)
                {
                    Fire();
                    attackTimer = 0f;
                }
            }
            // 대상이 사정 거리 밖에 있는 경우 다시 대상을 찾습니다.
            else if (Vector3.Distance(transform.position, target.transform.position) > range * GameManager.instance.modular + (GameManager.instance.modular / 2))
            {
                target = FindClosestEnemy();
            }
        }
    }

    // 가장 가까운 적을 찾습니다.
    protected GameObject FindClosestEnemy()
    {
        GetEnemies();
        GameObject closestEnemy = null;
        float closestDistance = range * GameManager.instance.modular + (GameManager.instance.modular / 2);
        for (int i = 0 ; i < enemies.Length; i++)
        {
            GameObject enemy = enemies[i];
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                //closestDistance = distance;
                closestEnemy = enemy;
                return closestEnemy;
            }
        }
        return closestEnemy;
    }

    // 대상을 공격합니다.
    protected virtual void Fire() { }

    protected void GenerateBullet()
    {
        GameObject bObject = pool.GetObjectFromPool();
        Bullet bullet = bObject.GetComponent<Bullet>();
        bullet.SetTarget(target);
        bullet.init(speed, damage, penetrate);
        bullet.setTransform(transform.position, transform.rotation.eulerAngles);
    }

    protected void RotateTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized; // 타겟 방향
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // 타겟 방향을 각도로 변환
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward); // 타겟 방향으로 회전할 Quaternion 생성
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // 부드럽게 회전
        transform.rotation = targetRotation; // 바로 회전
    }

    // 사정거리를 시각적으로 표시
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range * GameManager.instance.modular + (GameManager.instance.modular / 2));
    }
}
