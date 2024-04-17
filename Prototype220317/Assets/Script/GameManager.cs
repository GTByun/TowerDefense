using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float modular;
    public GameObject towerPlace;
    public GameObject towerPlaceParent;
    public static GameManager gameManager;
    public CardSpriteSet[] cards;
    public bool GameOn;
    private bool firstGame;

    public UIController UIController { get; private set; }
    public CardSpriteInfoSaver CardSpriteInfoSaver { get; private set; }
    public EditManager EditManager { get; private set; }
    public TowerTypeSaver TowerTypeSaver { get; private set; }

    void Awake()
    {
        //���ӸŴ��� �ν��Ͻ� ����
        if (gameManager == null)
            gameManager = this;
        //Ÿ�� ��ġ ������Ʈ ����. TowerPlaceParent�� �ڽ����� ����
        SetTowerPlace();
        //�Ŵ��� ��������
        SetManagers();
        //���� ������Ʈ
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
    private void SetTowerPlace()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Vector2 pos = new(i * modular - modular, modular - j * modular);
                GameObject obj = Instantiate(towerPlace, pos, Quaternion.identity);
                obj.transform.localScale = Vector2.one * modular;
                obj.transform.parent = towerPlaceParent.transform;
            }
        }
    }
    private void SetManagers()
    {
        UIController = gameObject.GetComponent<UIController>();
        CardSpriteInfoSaver = gameObject.GetComponent<CardSpriteInfoSaver>();
        EditManager = gameObject.GetComponent<EditManager>();
        TowerTypeSaver = gameObject.GetComponent<TowerTypeSaver>();
    }
}
