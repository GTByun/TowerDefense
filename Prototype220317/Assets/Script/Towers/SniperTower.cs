using UnityEngine;

public class SniperTower : Tower
{
    protected override void Start()
    {
        range = 3f;
        speed = 50f;
        damage = 100f;
        penetrate = 1;
        reloadDelay = 0.8f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}