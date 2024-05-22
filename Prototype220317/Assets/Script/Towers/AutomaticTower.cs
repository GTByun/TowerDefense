using UnityEngine;

public class AutomaticTower : Tower
{
    protected override void Start()
    {
        range = 2.5f;
        speed = 5f;
        damage = 25f;
        penetrate = 0;
        reloadDelay = 10f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
