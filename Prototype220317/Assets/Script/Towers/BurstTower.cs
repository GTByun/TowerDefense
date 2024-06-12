using UnityEngine;

public class BurstTower : Tower
{
    private int ammo;
    private float burstSpeed;


    protected override void Start()
    {
        base.Start();
        ammo = 3;
        burstSpeed = 20f;
    }
    protected override void Fire()
    {
        base.Fire();
        if (ammo == 0)
        {
            waitFind = false;
            ammo = 3;
            reloadSpeed = towerData.reloadSpeed;
        }
        else if (ammo>0)
        {
            waitFind = true;
            reloadSpeed = burstSpeed;
            ammo--;
            GenerateBullet();
        } 
    }
}
