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
        return TowerInfoArr[index].TowerObject;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �������� ������
    /// </summary>
    public Sprite GetIcon(int index)
    {
        return TowerInfoArr[index].TowerIcon;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� �̸��� ������
    /// </summary>
    public string GetName(int index)
    {
        return TowerInfoArr[index].TowerName;
    }
    /// <summary>
    /// ���� �ε������� �ش��ϴ� Ÿ���� ������ ������
    /// </summary>
    public string GetDescription(int index) 
    {
        return TowerInfoArr[index].TowerDescription;
    }
}


/// <summary>
/// �ϳ��� Ÿ���� ���� ��� ������ ������
/// </summary>
[System.Serializable]
public class TowerInfo
{
    //Ÿ���� ������, �̸�, ����, ������

    public Sprite TowerIcon;
    public string TowerName;
    public string TowerDescription;
    public GameObject TowerObject;
}
