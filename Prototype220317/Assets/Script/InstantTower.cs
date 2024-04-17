using UnityEngine;

public class InstantTower : Tower
{
    protected override void Start()
    {
        range = 3f;
        speed = 80f;
        damage = 9999f;
        penetrate = 0;
        reloadDelay = 0.5f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
