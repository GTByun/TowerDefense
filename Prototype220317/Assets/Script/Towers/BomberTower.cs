using UnityEngine;

public class BomberTower : Tower
{
    public float hitArea;
    public float splashArea;
    public float splashDamage;

    protected override void Start()
    {
        base.Start();
        speed = 3f;
        range = 5;
        damage = 80f;
        reloadDelay = 0.7f;
        hitArea = 1f;
        splashArea = 2f;
        splashDamage = 40f;
    }
    protected override void Fire()
    {
        GameObject bObject = pool.GetObjectFromPool();
        Bomb bomb = bObject.GetComponent<Bomb>();
        bomb.init(speed, damage, hitArea, splashArea, splashDamage);
        bomb.setTransform(transform.position, transform.rotation.eulerAngles);
        bObject.SetActive(true);
    }
}
