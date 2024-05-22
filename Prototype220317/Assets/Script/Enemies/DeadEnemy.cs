using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * 20, ForceMode2D.Impulse);
    }
}
