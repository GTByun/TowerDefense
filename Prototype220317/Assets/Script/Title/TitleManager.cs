using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    [SerializeField] private Material tile;
    public float speed = 1f;
    private float offset = 0;

    private void Update()
    {
        offset += Time.deltaTime;
        tile.SetTextureOffset("_MainTex", new Vector2(0, offset) * speed);
    }

    private void OnApplicationQuit()
    {
        tile.SetTextureOffset("_MainTex", new Vector2(0, 0));
    }
}
