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
        Debug.Log("Fire");
        if (radarEffectPrefab != null)
        {
            Debug.Log("fab !null");
            radarEffect = Instantiate(radarEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (radarEffect != null)
            {
                Debug.Log("Effect !null");
                radarEffect.Play();
            }
        }
    }

}