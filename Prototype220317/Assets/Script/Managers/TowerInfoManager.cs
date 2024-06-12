using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� Ÿ���� ���� ������ ������ �ִ� TowerInfo�� ��ü������ ������
/// </summary>
public class TowerInfoManager : MonoBehaviour 
{
    public int nDefaultTower = 4;
    public int nTower = 12;
    //TowerInfo�� �迭
    public TowerInfo[] TowerInfoArr = new TowerInfo[12];

    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �������� ������
    /// </summary>
    public GameObject GetObject(int index) 
    {
        return TowerInfoArr[index].towerObject;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �������� ������
    /// </summary>
    public Sprite GetIcon(int index)
    {
        return TowerInfoArr[index].towerData.towerIcon;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �̸��� ������
    /// </summary>
    public string GetName(int index)
    {
        return TowerInfoArr[index].towerData.towerName;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� ������ ������
    /// </summary>
    public string GetDescription(int index) 
    {
        return TowerInfoArr[index].towerData.towerDescription;
    }
}



