using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float modular; //그리드 크기
    public static GameManager instance; //static 인스턴스

    //매니저들
    public UIController uiController { get; private set; }
    public TowerInfoManager towerInfoManager { get; private set; }
    public StateManager stateManager { get; private set; }
    public GridManager gridManager { get; private set; }
    public CardManager cardManager { get; private set; }
    public GoogleAdMob googleAdMob { get; private set; }

    void Awake()
    {
        //인스턴스 생성
        if (instance == null)
            instance = this;
        //매니저들 지정
        SetManagers();
        //TowerPlace를 배치
        gridManager.SetTowerPlace(modular);
    }
    private void SetManagers()
    {
        uiController = gameObject.GetComponent<UIController>();
        towerInfoManager = gameObject.GetComponent<TowerInfoManager>();
        stateManager = gameObject.GetComponent<StateManager>();
        gridManager = gameObject.GetComponent<GridManager>();
        cardManager = gameObject.GetComponent<CardManager>();
        googleAdMob = gameObject.GetComponent<GoogleAdMob>();
    }
}
