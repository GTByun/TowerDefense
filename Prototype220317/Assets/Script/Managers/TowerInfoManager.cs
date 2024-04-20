using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �� Ÿ���� ���� ������ ������ �ִ� TowerInfo�� ��ü������ ������
/// </summary>
public class TowerInfoManager : MonoBehaviour 
{
    //TowerInfo�� �迭
    public TowerInfo[] TowerInfoArr = new TowerInfo[8];

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
        return TowerInfoArr[index].towerIcon;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �̸��� ������
    /// </summary>
    public string GetName(int index)
    {
        return TowerInfoArr[index].towerName;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� ������ ������
    /// </summary>
    public string GetDescription(int index) 
    {
        return TowerInfoArr[index].towerDescription;
    }
}



