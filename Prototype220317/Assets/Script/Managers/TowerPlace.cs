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
    public int towerIndex; //�� Ÿ���� �ε���

    private void Start()
    {
        gridManager = GameManager.instance.gridManager;
    }

    private void OnMouseDown()
    {
        Debug.Log("towerIndex : "+towerIndex);
        //Ŭ�� ����. �� Ŭ������ �Ű�Ⱦ�. �ϴ� �� index�� Ŭ���Ǿ��ٰ� �Լ� ȣ����
        gridManager.GridClicked(towerIndex);
    }
}
