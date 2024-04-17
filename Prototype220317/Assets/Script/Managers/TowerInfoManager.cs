using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�� Ÿ���� ���� ������ ������ �ִ� TowerInfo�� ��ü������ ������
public class TowerInfoManager : MonoBehaviour 
{
    //TowerInfo�� �迭
    public TowerInfo[] TowerInfoArr = new TowerInfo[8];

    
    public GameObject GetObject(int index) //���� �ε������� �ش��ϴ� Ÿ���� �������� ������
    {
        return TowerInfoArr[index].TowerObject;
    }
    public Sprite GetIcon(int index) //���� �ε������� �ش��ϴ� Ÿ���� �������� ������
    {
        return TowerInfoArr[index].TowerIcon;
    }
    public string GetName(int index) //���� �ε������� �ش��ϴ� Ÿ���� �̸��� ������
    {
        return TowerInfoArr[index].TowerName;
    }
    public string GetDescription(int index) //���� �ε������� �ش��ϴ� Ÿ���� ������ ������
    {
        return TowerInfoArr[index].TowerDescription;
    }
}



[System.Serializable] //TowerInfo�� �������� �ν�����â���� ���� �����ϵ��� ����
public class TowerInfo //�ϳ��� Ÿ���� ���� ��� ������ ������
{
    //Ÿ���� ������, �̸�, ����, ������

    public Sprite TowerIcon;
    public string TowerName;
    public string TowerDescription;
    public GameObject TowerObject;
}
