using System.Collections;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public float speed;
    public float damage;
    public int penetrate;

    public float hitInterval = 1.0f;
    public void init(float speed, float damage, int penetrate)
    {
        this.speed = speed;
        this.damage = damage;
        this.penetrate = penetrate;
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
            if (penetrate <= 0) gameObject.SetActive(false);
            penetrate--;
        }
    }
}