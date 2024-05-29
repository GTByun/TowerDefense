using UnityEngine;

public class ShockTower : Tower
{
    public float hitArea;
    public float splashArea;
    public float splashDamage;

    protected override void Start()
    {
        base.Start();
        hitArea = 0.3f;
        splashArea = 1.2f;
        splashDamage = 20f;
    }
    protected override void Fire()
    {
        GameObject bObject = pool.GetObjectFromPool();
        ShockBullet sb = bObject.GetComponent<ShockBullet>();
        sb.init(bulletSpeed, damage, hitArea, splashArea, splashDamage);
        sb.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }
}
