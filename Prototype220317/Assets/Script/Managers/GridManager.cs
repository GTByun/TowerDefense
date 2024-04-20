using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

/// <summary>
/// �׸��忡 ��ġ�� Ÿ���鿡 ���� ������ �����ϸ�, �� Ÿ���鿡�� ������ �� �ִ� Method�� ����
/// </summary>
public class GridManager : MonoBehaviour
{
    public GridInfo[] gridInfoArr = new GridInfo[9];
    public int towerInHand;
    [SerializeField] private GameObject towerPlace;
    [SerializeField] private GameObject towerPlaceParent;
    private StateManager stateManager;
    private TowerInfoManager towerInfoManager;

    private void Start()
    {
        stateManager = GameManager.instance.StateManager;
        towerInfoManager = GameManager.instance.TowerInfoManager;
    }

    public void SetEditMode()
    {

    }

    public void EditTower(int index)
    {
        GameManager.instance.StateManager.EnterState(GameState.EditMode);
    }

    public void TowerClicked(int index)
    {
        if (stateManager.gameState == GameState.EditMode && towerInHand != -1)
        {
            if (gridInfoArr[index].hasTower)
            {
                ChangeTower(index);
            }else
            {
                CreateTower(index);
            }
        }
    }

    private void ChangeTower(int index)
    {
        
    }

    private void CreateTower(int index)
    {
        GameObject obj = GameObject.Instantiate(towerInfoManager.GetObject(towerInHand));
        gridInfoArr[index].towerObject = obj;
        obj.transform.position = gridInfoArr[index].pos;
        towerInHand = -1;
        GameManager.instance.UIController.UpdateEditModeHUD();
    }

    public void SetTowerPlace(float modular)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                int index = i * 3 + j;
                Vector2 pos = new(j * modular - modular, modular - i * modular);
                GameObject obj = Instantiate(towerPlace, pos, Quaternion.identity);
                obj.transform.localScale = Vector2.one * modular;
                obj.transform.parent = towerPlaceParent.transform;
                obj.GetComponent<TowerPlace>().towerIndex = index;
                gridInfoArr[index] = new GridInfo(index, false, obj);
            }
        }
    }
}

