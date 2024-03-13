using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float modular;
    public GameObject towerPlace;
    public GameObject towerPlaceParent;
    public GameObject road;
    public GameObject roadParent;
    // Start is called before the first frame update
    void Awake()
    {
        int id = 0;
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Vector2 pos = new Vector2(i * modular - modular, modular - j * modular);
                GameObject obj = Instantiate(towerPlace, pos, Quaternion.identity);
                obj.transform.localScale = Vector2.one * modular;
                obj.transform.parent = towerPlaceParent.transform;
            }
        }
        float roadX = -modular * 3;
        float roadY = modular * 2;
        for (int i = 0;i < 5;i++)
        {
            roadX += modular;
            Vector2 pos = new Vector2(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }
        for (int i = 0; i < 4; i++)
        {
            roadY -= modular;
            Vector2 pos = new Vector2(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
