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
    GameManager gameManager;

    protected virtual void Start()
    {
        gameManager=GameManager.instance;
        enemies = EnemySpawner.enemies;
    }

    protected virtual void Update()
    {
        if (gameManager.stateManager.gameState == GameState.GameMode)
        {
            attackTimer += Time.deltaTime;
            // ����� ������ ���ο� ����� ã���ϴ�.
            if (target == null)
            {
                target = FindClosestEnemy();
            }
            // ����� ������ ���� �ð� �������� ������ �����մϴ�.
            else if (target != null)
            {
                RotateTowardsTarget();
                if (attackTimer >= 1f / reloadDelay)
                {
                    Fire();
                    attackTimer = 0f;
                }
                // ����� ���� �Ÿ� �ۿ� �ְų� ��Ȱ��ȭ ������ ��� �ٽ� ����� ã���ϴ�.
                if (!target.activeSelf)
                {
                    target = FindClosestEnemy();
                }
                if (Vector3.Distance(transform.position, target.transform.position) > range * GameManager.instance.modular + (GameManager.instance.modular / 2))
                {
                    target = FindClosestEnemy();
                }
            }
        }
    }

    // ���� ����� ���� ã���ϴ�.
    protected GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = range * GameManager.instance.modular + (GameManager.instance.modular / 2);
        for (int i = 0 ; i < enemies.Length; i++)
        {
            GameObject enemy = enemies[i];
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemy.activeSelf)
            {
                if (distance < closestDistance)
                {
                    //closestDistance = distance;
                    closestEnemy = enemy;
                    return closestEnemy;
                }
            }
        }
        return closestEnemy;
    }

    // ����� �����մϴ�.
    protected virtual void Fire() { }

    protected void GenerateBullet()
    {
        GameObject bObject = pool.GetObjectFromPool();
        Bullet bullet = bObject.GetComponent<Bullet>();
        bullet.SetTarget(target);
        bullet.init(speed, damage, penetrate);
        bullet.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }

    protected void RotateTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized; // Ÿ�� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Ÿ�� ������ ������ ��ȯ
        Quaternion targetRotation = Quaternion.AngleAxis(angle-90f, Vector3.forward); // Ÿ�� �������� ȸ���� Quaternion ����
        transform.rotation = targetRotation; // �ٷ� ȸ��
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // �ε巴�� ȸ��
    }

    // �����Ÿ��� �ð������� ǥ��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range * GameManager.instance.modular + (GameManager.instance.modular / 2));
    }
}
