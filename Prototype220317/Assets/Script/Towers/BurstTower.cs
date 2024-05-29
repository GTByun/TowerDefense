using UnityEngine;

public class BurstTower : Tower
{
    private int ammo;

    protected override void Start()
    {
        base.Start();
        ammo = 3;
        range = 2.5f;
        bulletSpeed = 10f;
        damage = 35f;
        penetrate = 0;
        reloadSpeed = 5.0f;
    }
    protected override void Fire()
    {
        if (ammo == 0)
        {
            ammo = 3;
            reloadSpeed = 1f;
        }
        else if (ammo>0)
        {
            reloadSpeed = 5.0f;
            ammo--;
            GenerateBullet();
        } 
    }
}
