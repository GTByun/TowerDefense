using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float rotationSpeed = 50f;

    public float range;

    protected float speed;
    protected float damage;
    protected int penetrate;

    protected float reloadDelay;
    private float attackTimer;

    protected GameObject target = null;
    public GameObject bulletObject;


    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        // ����� ������ ���ο� ����� ã���ϴ�.
        if (target == null)
        {
            target = FindClosestEnemy();
        }
        // ����� ������ ���� �ð� �������� ������ �����մϴ�.
        else if (target != null)
        {
            RotateTowardsTarget();
            // ����� ���� �Ÿ� �ۿ� �ִ� ��� �ٽ� ����� ã���ϴ�.
            attackTimer += Time.deltaTime;
            if (Vector3.Distance(transform.position, target.transform.position) < range * GameManager.gameManager.modular + (GameManager.gameManager.modular/2))
            {
                if (attackTimer >= 1f / reloadDelay)
                {
                    Fire();
                    attackTimer = 0f;
                }
            }
            if (Vector3.Distance(transform.position, target.transform.position) > range * GameManager.gameManager.modular + (GameManager.gameManager.modular / 2)) target = FindClosestEnemy();
        }
    }

    // ���� ����� ���� ã���ϴ�.
    protected GameObject FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closestEnemy = null;
        float closestDistance = 10;
        for (int i = 0; i < enemies.Length; i++)
        {
            GameObject enemy = enemies[i];
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
    // ����� �����մϴ�.
    protected virtual void Fire() { }

    protected void GenerateBullet()
    {
        GameObject bObject = Instantiate(bulletObject);
        Bullet bullet = bObject.GetComponent<Bullet>();
        bullet.init(speed, damage, penetrate);
        bullet.setTransform(transform.position, transform.rotation.eulerAngles);
        //bObject.SetActive(true);
    }

    protected void GenerateBullet(float fireAngle, float shell)
    {
        float angleOffset = fireAngle / (shell - 1);
        float startAngle = -fireAngle / 2f;
        float rotZ = startAngle;

        for (int i = 0; i < shell; i++)
        {
            GameObject bObject = Instantiate(bulletObject);
            Bullet bullet = bObject.GetComponent<Bullet>();
            bullet.init(speed, damage, penetrate);
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = rot.z + rotZ;
            bullet.setTransform(transform.position, rot);
            //bObject.SetActive(true);
            rotZ += angleOffset;
        }
    }
    protected void RotateTowardsTarget()
    {
        Vector3 direction = (target.transform.position - transform.position).normalized; // Ÿ�� ����
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Ÿ�� ������ ������ ��ȯ
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward); // Ÿ�� �������� ȸ���� Quaternion ����
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // �ε巴�� ȸ��
    }
    // �����Ÿ��� �ð������� ǥ��
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range * GameManager.gameManager.modular + (GameManager.gameManager.modular / 2));
    }
}
