using UnityEngine;

public class AutomaticTower : Tower
{
    protected override void Start()
    {
        range = 2.5f;
        bulletSpeed = 10f;
        damage = 25f;
        penetrate = 0;
        reloadSpeed = 10f;
        base.Start();
    }
    protected override void Fire()
    {
        GenerateBullet();
    }
}
