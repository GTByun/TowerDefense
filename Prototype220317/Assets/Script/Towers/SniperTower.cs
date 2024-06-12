using UnityEngine;

public class SniperTower : Tower
{
    protected override void Start()
    {
        base.Start();
    }
    protected override void Fire()
    {
        base.Fire();
        GenerateBullet();
    }
}
