using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float speed;
    public float damage;
    public float hitArea;
    public float splashArea;
    public float splashDamage;
    bool collisionLock;

    public GameObject explosionEffectPrefab;
    ParticleSystem explosionEffect;
    public void init(float speed, float damage, float hitArea, float splashArea, float splashDamage)
    {
        this.speed = speed;
        this.damage = damage * PlayerStatus.damageUpgrade;
        this.hitArea = hitArea;
        this.splashArea = splashArea;   
        this.splashDamage = splashDamage;
        collisionLock = false;
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
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GameArea") && gameObject.activeSelf)
        {
            Explode();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Explode();
            collisionLock = true;
        }
    }

    void Explode()
    {
        if (collisionLock) return;
        gameObject.SetActive(false);

        // ���� ����Ʈ�� ����
        if (explosionEffectPrefab != null)
        {
            explosionEffect = Instantiate(explosionEffectPrefab, transform.position, Quaternion.identity).GetComponent<ParticleSystem>();
            if (explosionEffect != null)
            {
                explosionEffect.Play();
            }
        }

        // ���� ���� ���� �ִ� ��� ���� ã�� �������� �ֱ�
        Collider2D[] collidersInSplash = Physics2D.OverlapCircleAll(transform.position, splashArea);
        foreach (Collider2D collider in collidersInSplash)
        {
            if (collider.CompareTag("Enemy"))
            {
                collider.GetComponent<Enemy>().Hit(splashDamage);
            }
        }
    }
}
