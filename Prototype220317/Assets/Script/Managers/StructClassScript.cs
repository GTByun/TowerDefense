using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    public int towerIndex; //Ÿ�� �ε���
    public GameObject towerPlace; //Ŭ�� ������ ������Ʈ
    public GameObject towerObject; //Ÿ�� ������Ʈ
    public Vector3 pos; //���� ��ġ

    public GridInfo(int index, GameObject towerPlace)
    {
        this.index = index;
        this.towerPlace = towerPlace;
        this.pos = towerPlace.transform.position;
        this.towerIndex = -1;
    }

    public void ResetTower()
    {
        this.towerIndex = -1;
        GameObject temp = this.towerObject;
        GameObject.Destroy(temp);
        towerObject = null;
    }
}
