using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �׸��忡 ��ġ�� Ÿ���鿡 ���� ������ �����ϸ�,
/// �� Ÿ���鿡�� ������ �� �ִ� Method�� ����
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
