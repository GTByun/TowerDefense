using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    private Rigidbody2D rb;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.zero;
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), 0.5f) * Random.Range(10f, 20f), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeleteZone")) gameObject.SetActive(false);
    }
}
