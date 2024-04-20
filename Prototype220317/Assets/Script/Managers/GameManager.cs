using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float modular;
    public GameObject towerPlace;
    public GameObject towerPlaceParent;
    public static GameManager instance;
    public CardSpriteSet[] cards;
    public bool GameOn;
    private bool firstGame;

    public UIController UIController { get; private set; }
    public TowerInfoManager TowerInfoManager { get; private set; }
    public StateManager StateManager { get; private set; }
    public GridManager gridManager { get; private set; }

    void Awake()
    {
        //인스턴스 생성
        if (instance == null)
            instance = this;
        //매니저들 지정
        SetManagers();
        //TowerPlace를 배치
        gridManager.SetTowerPlace(modular);
        //뭔지 모름
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
    private void SetManagers()
    {
        UIController = gameObject.GetComponent<UIController>();
        TowerInfoManager = gameObject.GetComponent<TowerInfoManager>();
        StateManager = gameObject.GetComponent<StateManager>();
        gridManager = gameObject.GetComponent<GridManager>();
    }
}
