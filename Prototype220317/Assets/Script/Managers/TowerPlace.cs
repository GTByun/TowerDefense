using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// TowerPlace�� ���� ��ũ��Ʈ�̸� �ܼ��� Ŭ�� �̺�Ʈ�� ������
/// </summary>
public class TowerPlace : MonoBehaviour
{
    private GridManager gridManager;
    public int towerIndex;

    private void Start()
    {
        gridManager = GameManager.instance.gridManager;
    }

    private void OnMouseDown()
    {
        gridManager.TowerClicked(towerIndex);
    }
}
