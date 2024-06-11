using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustWall : MonoBehaviour
{
    private bool isPositive;
    private void Awake()
    {
        isPositive = transform.position.x > 0;
    }

    private void Update()
    {
        float ratio = Screen.width * 1.0f / Screen.height * 1.0f;
        ratio = (ratio * 5) + 1;
        if (ratio < 6)
        {
            ratio = 6;
        }
        ratio *= isPositive ? 1 : -1;
        gameObject.transform.position = new Vector2(ratio, 0);
    }
}
