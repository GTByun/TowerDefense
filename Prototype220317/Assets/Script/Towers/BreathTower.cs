using UnityEngine;

public class BreathTower : Tower
{
    float fireAngle;
    int shell;
    new CircleCollider2D collider;
    float bulletRange;

    protected override void Start()
    {
        bulletRange = 4f;
        shell = 9;
        fireAngle = 90f;
        range = 2f;
        speed = 3f;
        damage = 20f;
        penetrate = 20;
        reloadDelay = 0.5f;
        base.Start();
    }
    // 사거리내 가장 나중에 생성된 적을 찾습니다.
    protected override GameObject FindClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = range * GameManager.instance.modular + (GameManager.instance.modular / 2);
        for (int i = EnemySpawner.enemies.Count-1; i >= 0; i--)
        {
            GameObject enemy = EnemySpawner.enemies[i];
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
    protected override void Fire()
    {
        float angleOffset = fireAngle / (shell - 1);
        float startAngle = -fireAngle / 2f;
        float rotZ = startAngle;

        for (int i = 0; i < shell; i++)
        {
            GameObject bObject = pool.GetObjectFromPool();
            Fire bullet = bObject.GetComponent<Fire>();
            bullet.init(speed, damage, penetrate, bulletRange);
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = rot.z + rotZ;
            bullet.setTransform(transform.position, rot);
            rotZ += angleOffset;
            bObject.SetActive(true);
        }
    }
}
