using UnityEngine;

public class BurstTower : Tower
{
    private int ammo;
    private float burstSpeed;


    protected override void Start()
    {
        base.Start();
        ammo = 3;
        burstSpeed = 10f;
    }
    protected override void Fire()
    {
        if (ammo == 0)
        {
            ammo = 3;
            reloadSpeed = towerData.reloadSpeed;
        }
        else if (ammo>0)
        {
            reloadSpeed = burstSpeed;
            ammo--;
            GenerateBullet();
        } 
    }
}
