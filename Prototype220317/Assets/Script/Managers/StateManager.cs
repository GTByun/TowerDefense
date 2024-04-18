using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 
/// State를 관리해주는 매니저
/// </summary>
public class StateManager : MonoBehaviour
{
    public GameState gameState = GameState.SelectReward;
    private UIController UIController;
    private EditManager EditManager;

    void Start() {
        UIController = GameManager.instance.UIController;
        EditManager = GameManager.instance.EditManager;
    }

    public void EnterState(GameState state) {
        switch (state) {
            case GameState.SelectReward :
                UIController.CardModeOn();
                break;
            case GameState.EditMode :
                UIController.EditModeOn();
                EditManager.SetEditMode();
                break;
        }
    }

    public void ExitState(GameState state) {

    }

    public void AdvanceState() {
    }

    public void InitState() {
        EnterState(GameState.SelectReward);
    }
}
