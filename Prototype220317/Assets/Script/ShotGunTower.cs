using UnityEngine;

public class ShotGunTower : Tower
{
    float fireAngle;
    int shell;

    protected override void Start()
    {
        shell = 5;
        fireAngle = 60f;
        range = 1f;
        speed = 30f;
        damage = 15f;
        penetrate = 0;
        reloadDelay = 1.0f;
        base.Start();
    }

    protected override void Fire()
    {
        GenerateBullet(fireAngle, shell);

    }
}
