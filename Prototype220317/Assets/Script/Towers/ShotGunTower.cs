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
            Vector3 rot = transform.rotation.eulerAngles;
            rot.z = rot.z + rotZ;
            GenerateBulletWithOutTarget(transform.position, rot);
            rotZ += angleOffset;
        }
    }
}
