using UnityEngine;

public class AutomaticTower : Tower
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
