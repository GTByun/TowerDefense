using UnityEngine;

public class ShotGunTower : Tower
{
    float fireAngle;
    int ball;

    protected override void Start()
    {
        ball = 6;
        fireAngle = 60f;
        base.Start();
    }

    protected override void Fire()
    {
        float angleOffset = fireAngle / (ball - 1);
        float startAngle = -fireAngle / 2f;
        float rotZ = startAngle;
        
        for (int i = 0; i < ball; i++)
        {
            GameObject bObject = pool.GetObjectFromPool();
            Bullet bullet = bObject.GetComponent<Bullet>();
            bullet.init(bulletSpeed, damage, penetrate);
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = rot.z + rotZ;
            bullet.setTransform(transform.position, rot);
            rotZ += angleOffset;
            bObject.SetActive(true);
        }
    }
}
