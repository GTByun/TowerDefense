using UnityEngine;

public class SniperTower : Tower
{
    protected override void Start()
    {
        range = 3f;
        bulletSpeed = 20f;
        damage = 100f;
        penetrate = 0;
        reloadSpeed = 0.8f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
