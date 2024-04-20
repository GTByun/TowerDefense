using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �ϳ��� Ÿ���� ���� ��� ������ ������
/// </summary>
[System.Serializable]
public class TowerInfo
{
    //Ÿ���� ������, �̸�, ����, ������
    public Sprite towerIcon;
    public string towerName;
    public string towerDescription;
    public GameObject towerObject;
}

/// <summary>
///  �ش� �׸��忡 ���� Ÿ���� �ִ���, ��Ÿ ��� ������ ������
/// </summary>
[System.Serializable]
public class GridInfo
{
    public int index; //index��° �׸���
    public bool hasTower; //Ÿ�� ����
    public GameObject towerPlace; //Ŭ�� ������ ������Ʈ
    public GameObject towerObject; //Ÿ�� ������Ʈ
    public Vector3 pos; //���� ��ġ

    public GridInfo(int index, bool hasTower, GameObject towerPlace)
    {
        this.index = index;
        this.hasTower = hasTower;
        this.towerPlace = towerPlace;
        this.pos = towerPlace.transform.position;
    }
}
