using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private EditManager editManager;
    private GameObject nowTower;
    private TowerTypeSaver towerTypeSaver;
    public GameObject[] towerPrefab;
    private int towerId;
    private bool editModeOn;

    private void Start()
    {
        editManager = GameManager.gameManager.editManager;
        towerTypeSaver = GameManager.gameManager.towerTypeSaver;
    }

    void TowerCreate(int id)
    {
        if (nowTower == null)
        {
            nowTower = Instantiate(towerTypeSaver.towers[id], gameObject.transform);
            towerId = id;
            editModeOn = false;
        }
    }

    void TowerChange(int id, int checkId)
    {
        if (towerId == checkId)
        {
            Destroy(nowTower);
            nowTower = Instantiate(towerTypeSaver.towers[id], gameObject.transform);
            towerId = id;
            editModeOn = false;
        }
    }

    private void OnMouseDown()
    {
        if (editManager.isEdit)
        {
            int editId = editManager.editId;
            editModeOn = true;
            switch (editId) 
            {
                case 0:
                    TowerCreate(editId);
                    break;
                case 1:
                    TowerChange(editId, 0);
                    break;
                case 2:
                    TowerChange(editId, 0);
                    break;
                case 3:
                    TowerCreate(editId);
                    break;
                case 4:
                    TowerChange(editId, 3);
                    break;
                case 5:
                    TowerChange(editId, 3);
                    break;
                case 6:
                    TowerCreate(editId);
                    break;
                case 7:
                    TowerChange(editId, 0);
                    break;
            }
            editManager.isEdit = editModeOn;
        }
    }
}
