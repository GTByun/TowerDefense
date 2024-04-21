using UnityEngine;

public class BurstTower : Tower
{
    private int ammo;

    protected override void Start()
    {
        base.Start();
        ammo = 3;
        range = 2f;
        speed = 5f;
        damage = 8f;
        penetrate = 0;
        reloadDelay = 2.5f;
    }
    protected override void Fire()
    {
        if (ammo == 0)
        {
            ammo = 3;
            reloadDelay = 1f;
        }
        else if (ammo>0)
        {
            reloadDelay = 2.5f;
            ammo--;
            GenerateBullet();
        } 
    }
}
