using UnityEngine;

public class BomberTower : Tower
{
    public float hitArea;
    public float splashArea;
    public float splashDamage;

    protected override void Start()
    {
        base.Start();
        hitArea = 1f;
        splashArea = 2.5f;
    }
    protected override void Fire()
    {
        GameObject bObject = pool.GetObjectFromPool();
        Bomb bomb = bObject.GetComponent<Bomb>();
        bomb.init(bulletSpeed, damage, hitArea, splashArea);
        bomb.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }
}
