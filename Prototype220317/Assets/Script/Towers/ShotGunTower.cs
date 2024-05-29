using UnityEngine;

public class ShotGunTower : Tower
{
    float fireAngle;
    int shell;

    protected override void Start()
    {
        shell = 6;
        fireAngle = 60f;
        range = 2f;
        bulletSpeed = 7f;
        damage = 30f;
        penetrate = 0;
        reloadSpeed = 0.9f;
        base.Start();
    }

    protected override void Fire()
    {
        float angleOffset = fireAngle / (shell - 1);
        float startAngle = -fireAngle / 2f;
        float rotZ = startAngle;
        
        for (int i = 0; i < shell; i++)
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
