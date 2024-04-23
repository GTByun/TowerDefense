using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// State를 관리해주는 매니저
/// </summary>
public class StateManager : MonoBehaviour
{
    public GameState gameState = GameState.None; //현재 게임의 상태
    private UIController uiController;

    void Start() {
        uiController = GameManager.instance.uiController;
    }

    /// <summary>
    /// 상태에 진입함
    /// </summary>
    /// <param name="state">진입할 상태</param>
    public void EnterState(GameState state) {
        switch (state) {
            case GameState.SelectReward :
                uiController.CardModeOn();
                
                break;
            case GameState.EditMode :
                uiController.EditModeOn();
                break;
            case GameState.GameMode :
                uiController.GameModeOn();
                break;
        }
        gameState = state;
    }

    /// <summary>
    /// 상태에 진입함. 몇몇 인스펙터 창에서 사용가능하도록 int를 제공함. 웬만해서는 위에꺼 쓰셈
    /// </summary>
    /// <param name="stateIndex">진입할 상태</param>
    public void EnterState(int stateIndex)
    {
        EnterState((GameState)stateIndex);
    }
}
