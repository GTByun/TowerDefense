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
        //게임매니저 인스턴스 저장
        if (gameManager == null)
            gameManager = this;
        //타워 배치 오브젝트 생성. TowerPlaceParent에 자식으로 지정
        SetTowerPlace();
        //매니저 가져오기
        SetManagers();
        //게임 스테이트
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
