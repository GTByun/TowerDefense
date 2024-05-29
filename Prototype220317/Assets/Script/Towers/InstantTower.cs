using UnityEngine;

public class InstantTower : Tower
{
    protected override void Start()
    {
        range = 3f;
        bulletSpeed = 20f;
        damage = 99999f;
        penetrate = 0;
        reloadSpeed = 0.5f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
