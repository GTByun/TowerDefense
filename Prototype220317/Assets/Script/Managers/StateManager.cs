using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// State를 관리해주는 매니저
/// </summary>
public class StateManager : MonoBehaviour
{
    public GameState gameState = GameState.None;
    private UIController UIController;

    void Start() {
        UIController = GameManager.instance.UIController;
    }

    public void EnterState(GameState state) {
        switch (state) {
            case GameState.SelectReward :
                UIController.CardModeOn();
                break;
            case GameState.EditMode :
                UIController.EditModeOn();
                break;
            case GameState.GamePlay :
                UIController.GameModeOn();
                break;
        }
        gameState = state;
    }

    public void EnterState(int stateIndex)
    {
        EnterState((GameState)stateIndex);
    }

    public void ExitState(GameState state) {

    }

    public void AdvanceState() {
    }
}
