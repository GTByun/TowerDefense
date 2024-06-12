using UnityEngine;

public class BuckShotTower : Tower
{
    int shell;
    float doubleSpeed;
    float barrelOffset;
    bool leftBarrel;

    protected override void Start()
    {
        shell = 2;
        doubleSpeed = 5f;
        barrelOffset = 0.25f; 
        leftBarrel = true;
        base.Start();
    }

    protected override void Fire()
    {
        base.Fire();
        // �ι� �ѹ��� �߻�
        GenerateBulletWithOutTarget(transform.position + transform.right * barrelOffset, transform.rotation.eulerAngles);
        GenerateBulletWithOutTarget(transform.position + transform.right * -barrelOffset, transform.rotation.eulerAngles);
        
        //GameObject bObject = pool.GetObjectFromPool();
        //Bullet bullet = bObject.GetComponent<Bullet>();
        //bullet.init(bulletSpeed, damage, penetrate);
        //bullet.setTransform(transform.position + transform.right * barrelOffset, transform.rotation.eulerAngles);
        //bObject.SetActive(true); 

        //bObject = pool.GetObjectFromPool();
        //bullet = bObject.GetComponent<Bullet>();
        //bullet.init(bulletSpeed, damage, penetrate);
        //bullet.setTransform(transform.position + transform.right * -barrelOffset, transform.rotation.eulerAngles);
        //bObject.SetActive(true);

        // �ѹ߾� ���� �ΰ� �߻��ϴ� �κ�
        /*if (shell <= 0) 
        {
            shell = 2;
            reloadSpeed = towerData.reloadSpeed;
            leftBarrel = true;
        }
        else if (shell > 0)
        {
            reloadSpeed = doubleSpeed;
            shell--;
            GameObject bObject = pool.GetObjectFromPool();
            Bullet bullet = bObject.GetComponent<Bullet>();
            bullet.init(bulletSpeed, damage, penetrate);
            if (leftBarrel) 
                bullet.setTransform(transform.position + transform.right * -barrelOffset, transform.rotation.eulerAngles);
            if (!leftBarrel) 
                bullet.setTransform(transform.position + transform.right * barrelOffset, transform.rotation.eulerAngles);
            leftBarrel = false;
            bObject.SetActive(true);
        }*/
    }
}
