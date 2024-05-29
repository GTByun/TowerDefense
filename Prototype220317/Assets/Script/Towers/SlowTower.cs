using UnityEngine;

public class SlowTower : Tower
{
    public GameObject radarEffectPrefab;
    ParticleSystem radarEffect;
    float slowScale;

    protected override void Start()
    {
        damage = 10f;
        range = 5f;
        reloadDelay = 0.7f;
        slowScale = 0.75f;
        base.Start();       
    }

    protected override void Fire()
    {
        for (int i = 0; i < EnemySpawner.enemies.Count; i++)
        {
            Enemy e = EnemySpawner.enemies[i].GetComponent<Enemy>();
            e.SlowDown(slowScale);
            e.Hit(damage);
        }
        if (radarEffectPrefab != null)
        {
            radarEffect = Instantiate(radarEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (radarEffect != null)
            {
                radarEffect.Play();
            }
        }
    }

}