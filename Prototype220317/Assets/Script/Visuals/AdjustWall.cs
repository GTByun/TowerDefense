using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustWall : MonoBehaviour
{
    private void Awake()
    {
        float ratio = Screen.width * 1.0f / Screen.height * 1.0f;
        ratio = (ratio * 5) + 1;
        ratio *= transform.position.x > 0 ? 1 : -1;
        gameObject.transform.position = new Vector2 (ratio, 0);
        Destroy(gameObject.GetComponent<AdjustWall>());
    }
}
