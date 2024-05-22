using UnityEngine;

public class SlowTower : Tower
{
    public GameObject radarEffectPrefab;
    ParticleSystem radarEffect;
    float slowScale;

    protected override void Start()
    {
        range = 5f;
        reloadDelay = 0.7f;
        slowScale = 0.7f;
        base.Start();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Enemy>().SlowDown(slowScale);
        }
    }

    protected override void Fire()
    {
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