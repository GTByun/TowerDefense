using UnityEngine;

public class SniperTower : Tower
{
    protected override void Start()
    {
        range = 3f;
        speed = 20f;
        damage = 100f;
        penetrate = 0;
        reloadDelay = 0.8f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
