using UnityEngine;

public class ChainTower : Tower
{
 
    int cushion;
    float cushionRange;
    float damageReduce;
    protected override void Start()
    {
        cushion = 3;
        cushionRange = 5f;
        damageReduce = 0.7f;
        base.Start();
    }
    protected override void Fire()
    {
        GameObject bObject = pool.GetObjectFromPool();
        ChainBullet bullet = bObject.GetComponent<ChainBullet>();
        Debug.Log(target);
        bullet.SetTarget(target);
        bullet.init(bulletSpeed, damage, cushion, cushionRange, damageReduce);
        bullet.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }
}
