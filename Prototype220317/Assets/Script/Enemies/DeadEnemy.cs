using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    float time = 0;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(1, 1) * 30, ForceMode2D.Impulse);
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (time > 6) Destroy(gameObject);
    }
}
