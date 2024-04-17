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
    public static GameManager gameManager;
    public CardSpriteSet[] cards;
    public bool GameOn;
    private bool firstGame;

    public UIController UIConroller { get; private set; }
    public CardSpriteInfoSaver CardSpriteInfoSaver { get; private set; }
    public EditManager EditManager { get; private set; }
    public TowerTypeSaver TowerTypeSaver { get; private set; }

    void Awake()
    {
        if (gameManager == null)
            gameManager = this;
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Vector2 pos = new(i * modular - modular, modular - j * modular);
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
            Vector2 pos = new(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }
        for (int i = 0; i < 4; i++)
        {
            roadY -= modular;
            Vector2 pos = new(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }
        for (int i = 0; i < 4; i++)
        {
            roadX -= modular;
            Vector2 pos = new(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }
        for (int i = 0; i < 3; i++)
        {
            roadY += modular;
            Vector2 pos = new(roadX, roadY);
            GameObject obj = Instantiate(road, pos, Quaternion.identity);
            obj.transform.localScale = Vector2.one * modular;
            obj.transform.parent = roadParent.transform;
        }
        UIConroller = gameObject.GetComponent<UIController>();
        CardSpriteInfoSaver = gameObject.GetComponent<CardSpriteInfoSaver>();
        EditManager = gameObject.GetComponent<EditManager>();
        TowerTypeSaver = gameObject.GetComponent<TowerTypeSaver>();
        GameOn = false;
        firstGame = true;
    }

    void Update()
    {
        if (GameOn)
        {
            if (firstGame)
            {
                GameOn = false;
                firstGame = false;
                StartCoroutine(FirstGameStart());
            }
        }
    }

    IEnumerator FirstGameStart()
    {
        yield return new WaitForSeconds(3);
        GameOn = true;
    }
}
