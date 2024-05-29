using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    float speed;
    float damage;
    int penetrate;
    float bulletRange;
    Vector3 towerPos;

    public float hitInterval = 1.0f;
    public void init(float speed, float damage, int penetrate, float bulletRange)
    {
        this.speed = speed;
        this.damage = damage;
        this.penetrate = penetrate;
        this.bulletRange = bulletRange;
    }
    public void setTransform(Vector3 pos, Vector3 rot)
    {
        towerPos = pos;
        transform.position = pos;
        transform.rotation = Quaternion.Euler(rot);
    }
    void Start()
    {

    }
    void Update()
    {
        if(Vector3.Distance(towerPos, transform.position) > bulletRange) gameObject.SetActive(false);
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Breath"))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Burn(damage);
        }
    }
}