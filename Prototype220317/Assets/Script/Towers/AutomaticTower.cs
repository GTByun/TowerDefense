using UnityEngine;

public class AutomaticTower : Tower
{
    protected override void Start()
    {
        range = 2f;
        speed = 40f;
        damage = 3f;
        penetrate = 0;
        reloadDelay = 10f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}