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
    public GridInfo[] gridInfoArr = new GridInfo[9]; //�� �׸��忡 ��ġ�Ǵ� Ÿ���� ���� �迭
    public int towerInHand; //�տ� ������ �ִ� Ÿ��. Ÿ���� ��ġ�� ��, �տ� ���� Ÿ���� ������ �� �� Ÿ���� ��ġ��
    [SerializeField] private GameObject towerPlace; //Ŭ�� ������ ������Ʈ
    [SerializeField] private GameObject towerPlaceParent; //towerPlace�� �θ�
    private StateManager stateManager;
    private TowerInfoManager towerInfoManager;
    private UIController uiController;

    private void Start()
    {
        stateManager = GameManager.instance.stateManager;
        towerInfoManager = GameManager.instance.towerInfoManager;
        uiController = GameManager.instance.uiController;
    }

    /// <summary>
    /// �տ� ��� �ִ� Ÿ���� ������. UI�� ������Ʈ��.
    /// </summary>
    /// <param name="tower">����� Ÿ���� �ε���</param>
    public void SetHand(int tower)
    {
        towerInHand = tower;
        uiController.UpdateEditModeHUD();
    }
    /// <summary>
    /// �׸��尡 Ŭ���Ǿ��� �� ȣ��Ǵ� �Լ���
    /// </summary>
    /// <param name="index">index��°�� �׸��尡 Ŭ����</param>
    public void GridClicked(int index)
    {
        if (stateManager.gameState == GameState.EditMode && towerInHand != -1)//������������� �տ� ī�尡 �ִ����� ���� üũ��
        {
            if (gridInfoArr[index].hasTower)//�� �׸��忡 Ÿ���� �ִٸ�
            {
                ChangeTower(index);
            }else
            {
                CreateTower(index);
            }
        }
    }

    /// <summary>
    /// index��° �׸��忡 �ִ� Ÿ���� �տ� �ִ� Ÿ���� ��ü��
    /// </summary>
    /// <param name="tower">��� �׸����� index</param>
    private void ChangeTower(int index)
    {
        
    }

    /// <summary>
    /// index��° �׸��忡 �տ� �ִ� Ÿ���� ��ġ��
    /// </summary>
    /// <param name="index">��� �׸����� index</param>
    private void CreateTower(int index)
    {
        GameObject obj = GameObject.Instantiate(towerInfoManager.GetObject(towerInHand));//Ÿ�� ���� �� �ʱ�ȭ
        gridInfoArr[index].towerObject = obj;
        obj.transform.position = gridInfoArr[index].pos;
        SetHand(-1); //���� �����
    }

    /// <summary>
    /// ��ȸ�� TowerPlace ��ġ �Լ�
    /// </summary>
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

