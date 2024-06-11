using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// State를 관리해주는 매니저
/// </summary>
public class StateManager : MonoBehaviour
{
    public GameState gameState = GameState.None; //현재 게임의 상태
    private UIController uiController;
    private CardManager cardManager;
    public UnityEvent WaveStarted;
    private int nCard = 0;

    void Start() {
        uiController = GameManager.instance.uiController;
        cardManager = GameManager.instance.cardManager;
        StartCoroutine("SlowUpdate");
        uiController.CardModeOn();
        StartCoroutine(nameof(LateRandomized));
    }

    /// <summary>
    /// 굳이 매 프레임마다 업데이트될 필요 없는 함수들을 1초마다 한번씩 불러줍니다.
    /// </summary>
    /// <returns></returns>
    IEnumerator SlowUpdate()
    {
        while (true) {
            if (gameState == GameState.GameMode) WatchWaveEnd();
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator LateRandomized()
    {
        yield return new WaitForFixedUpdate();
        cardManager.RandomizeCards();
    }

    /// <summary>
    /// 상태에 진입함
    /// </summary>
    /// <param name="state">진입할 상태</param>
    public void EnterState(GameState state)
    {
        GameState preState = gameState;
        gameState = state;
        Debug.Log($"{preState} -> {gameState}");
        switch (state) {
            case GameState.None:
                uiController.ResetUI();
                break;
            case GameState.SelectReward:
                uiController.CardModeOn();
                cardManager.RandomizeCards();
                break;
            case GameState.EditMode :
                uiController.EditModeOn();
                break;
            case GameState.GameMode :
                uiController.GameModeOn();
                if (preState!=GameState.GameOver) WaveStarted.Invoke();
                break;
            case GameState.GameOver:
                uiController.GameOverOn();
                break;
        }
    }

    /// <summary>
    /// 상태에 진입함. 몇몇 인스펙터 창에서 사용가능하도록 int를 제공함. 웬만해서는 위에꺼 쓰셈
    /// </summary>
    /// <param name="stateIndex">진입할 상태</param>
    public void EnterState(int stateIndex)
    {
        EnterState((GameState)stateIndex);
    }


    /// <summary>
    /// 카드 애니메이션용 함수.
    /// 카드가 완전히 사라지고 나면 BumpCard 호출합니다. 3번 호출(모든 카드가 사라짐)된다면 EditMode 상태로 넘어갑니다.
    /// </summary>
    public void BumpCard()
    {
        nCard++;
        if (nCard > 2)
        {
            EnterState(GameState.EditMode);
            nCard = 0;
        }
    }

    /// <summary>
    /// 웨이브가 끝났는지 계속 확인해주는 함수입니다. GameMode 상태에서만 돌아가며, 웨이브가 끝났다면 SelectReward 상태로 넘어갑니다.
    /// </summary>
    private void WatchWaveEnd()
    {
        /* 
        웨이브가 끝났는지 확인하려면,
        1. waveEnemy가 비어있음 == 이번 웨이브에 스폰할 모든 적을 스폰함
        2. enemies가 비어있음 == 필드 위에 적이 없음
        둘다 만족하면 됩니다.
        */
        if (EnemySpawner.waveEnemy.Count == 0 && EnemySpawner.enemies.Count == 0)
        {
            EnterState(GameState.SelectReward);
        }
    }
}
