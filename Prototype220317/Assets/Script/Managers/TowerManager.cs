using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 그리드에 배치된 타워들에 대한 정보를 제공하며,
/// 각 타워들에게 접근할 수 있는 Method가 있음
/// </summary>
public class TowerManager : MonoBehaviour
{
    public bool isEdit = false;
    public int editId;
    private UIController UIController;

    private void Awake()
    {
        UIController = GameManager.instance.UIController;
    }

    public void SetEditMode()
    {
        isEdit = true;
        if (editId > 14)
        {
            UIController.GameModeOn();
        }
    }

    public void EditTower(int index)
    {
        GameManager.instance.StateManager.EnterState(GameState.EditMode);
        editId = index;
    }
}
