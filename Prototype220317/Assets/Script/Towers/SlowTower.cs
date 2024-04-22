using UnityEngine;

public class SlowTower : Tower
{
    public GameObject radarEffectPrefab;
    ParticleSystem radarEffect;

    protected override void Start()
    {
        range = 5f;
        reloadDelay = 1f;
        base.Start();
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