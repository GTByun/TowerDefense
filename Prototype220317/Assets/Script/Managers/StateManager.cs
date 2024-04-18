using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ���� ������ ���� State���� ������
/// State�� �����ϰų� ������ �� ��� �κ��� ���� �Ѿ� �ϴ��� ������
/// </summary>
public class StateManager : MonoBehaviour
{
    public GameState gameState = GameState.SelectReward;
    private UIController UIController;

    void Start() {
        UIController = GameManager.gameManager.UIController;
    }

    public void EnterState(GameState state) {
        switch (state) {
            case GameState.SelectReward :
                UIController.CardModeOn();
                break;
            case GameState.EditMode :
                UIController.EditModeOn();
                break;
        }
    }

    public void ExitState(GameState state) {

    }

    public void AdvanceState() {
    }

    public void initState() {
        EnterState(GameState.SelectReward);
    }
}
