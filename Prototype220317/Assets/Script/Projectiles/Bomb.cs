using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;
    public float damage;
    public float hitArea;
    public float splashArea;
    public float splashDamage;
    public bool stop;

    public GameObject explosionEffectPrefab;
    ParticleSystem explosionEffect;
    public void init(float speed, float damage, float hitArea, float splashArea, float splashDamage)
    {
        this.speed = speed;
        this.damage = damage;
        this.hitArea = hitArea;
        this.splashArea = splashArea;   
        this.splashDamage = splashDamage;
        stop = false;
    }
    public void setTransform(Vector3 pos, Vector3 rot)
    {
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
    }
    void Start()
    { 

    }
    void Update()
    {
        if(!stop) transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GameArea"))
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    void Explode()
    {
        stop = true;
        gameObject.SetActive(false);

        // 폭발 이펙트를 생성
        if (explosionEffectPrefab != null)
        {
            explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (explosionEffect != null)
            {
                explosionEffect.Play();
            }
        }

        // 폭발 범위 내에 있는 모든 적을 찾아 데미지를 주기
        Collider2D[] collidersInSplash = Physics2D.OverlapCircleAll(transform.position, splashArea);
        foreach (Collider2D collider in collidersInSplash)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().Hit(splashDamage);
            }
        }
        Collider2D[] collidersInHit = Physics2D.OverlapCircleAll(transform.position, hitArea);
        foreach (Collider2D collider in collidersInHit)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().Hit(damage - splashDamage);
            }
        }
    }
}
