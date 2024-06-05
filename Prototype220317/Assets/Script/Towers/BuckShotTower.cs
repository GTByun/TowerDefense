using UnityEngine;

public class BuckShotTower : Tower
{
    int shell;
    float doubleSpeed;

    protected override void Start()
    {
        shell = 2;
        doubleSpeed = 10f;
        base.Start();
    }

    protected override void Fire()
    {
        if (shell <= 0)
        {
            waitFind = false;
            shell = 2;
            reloadSpeed = towerData.reloadSpeed;
        }
        else if (shell > 0)
        {
            waitFind = true;
            reloadSpeed = doubleSpeed;
            shell--;
            GameObject bObject = pool.GetObjectFromPool();
            Bullet bullet = bObject.GetComponent<Bullet>();
            bullet.init(bulletSpeed, damage, penetrate);
            bullet.setTransform(transform.position, transform.rotation.eulerAngles);
            bObject.SetActive(true);
        }        
    }
}
