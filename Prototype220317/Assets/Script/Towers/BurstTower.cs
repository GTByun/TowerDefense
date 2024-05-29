using UnityEngine;

public class BurstTower : Tower
{
    private int ammo;

    protected override void Start()
    {
        base.Start();
        ammo = 3;
        range = 2.5f;
        speed = 10f;
        damage = 35f;
        penetrate = 0;
        reloadDelay = 5.0f;
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
            reloadDelay = 5.0f;
            ammo--;
            GenerateBullet();
        } 
    }
}
