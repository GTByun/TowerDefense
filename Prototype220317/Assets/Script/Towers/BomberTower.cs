using UnityEngine;

public class BomberTower : Tower
{
    public float hitArea;
    public float splashArea;
    public float splashDamage;

    protected override void Start()
    {
        base.Start();
        bulletSpeed = 3f;
        range = 5;
        damage = 80f;
        reloadSpeed = 0.7f;
        hitArea = 1f;
        splashArea = 2.5f;
        splashDamage = 50f;
    }
    protected override void Fire()
    {
        GameObject bObject = pool.GetObjectFromPool();
        Bomb bomb = bObject.GetComponent<Bomb>();
        bomb.init(bulletSpeed, damage, hitArea, splashArea, splashDamage);
        bomb.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }
}
