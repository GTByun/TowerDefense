using UnityEngine;

public class InstantTower : Tower
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
