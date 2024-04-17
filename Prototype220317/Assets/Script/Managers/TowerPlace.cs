using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private EditManager editManager;
    private GameObject nowTower;
    private TowerInfoManager TowerInfoManager;
    private UIController uIController;
    private int towerId;
    private int attackRank;
    private int attackSpeedRank;

    private void Awake()
    {
        towerId = -1;
        attackRank = 0;
        attackSpeedRank = 0;
    }

    private void Start()
    {
        editManager = GameManager.gameManager.EditManager;
        TowerInfoManager = GameManager.gameManager.TowerInfoManager;
        uIController = GameManager.gameManager.UIController;
    }

    bool TowerCreate(int id)
    {
        if (nowTower == null)
        {
            nowTower = Instantiate(TowerInfoManager.GetObject(id), gameObject.transform);
            towerId = id;
            return false;
        }
        return true;
    }

    bool TowerChange(int id, int checkId)
    {
        if (towerId == checkId)
        {
            Destroy(nowTower);
            nowTower = Instantiate(TowerInfoManager.GetObject(id), gameObject.transform);
            towerId = id;
            return false;
        }
        return true;
    }

    private void OnMouseDown()
    {
        if (editManager.isEdit)
        {
            bool editModeOn = true;
            int editId = editManager.editId;
            if (editId < 12)
            {
                editModeOn = editId % 3 == 0 ? TowerCreate(editId) : TowerChange(editId, editId / 3);
            }
            else
            {
                if (nowTower != null)
                {
                    switch (editId)
                    {
                        case 12:
                            attackRank++;
                            break;
                        case 13:
                            attackSpeedRank++;
                            break;
                    }
                }
            }
            if (!editModeOn)
            {
                editManager.SetEditMode(editModeOn);
                uIController.GameModeOn();
                GameManager.gameManager.GameOn = true;
            }
        }
    }
}
