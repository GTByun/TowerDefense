using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 하나의 타워에 대한 모든 정보를 보관함
/// </summary>
[System.Serializable]
public class TowerInfo
{
    //타워의 아이콘, 이름, 설명, 프리팹
    public Sprite towerIcon;
    public string towerName;
    public string towerDescription;
    public GameObject towerObject;
}

/// <summary>
///  해당 그리드에 무슨 타워가 있는지, 기타 등등 정보를 보관함
/// </summary>
[System.Serializable]
public class GridInfo
{
    public int index; //index번째 그리드
    public bool hasTower; //타워 유무
    public GameObject towerPlace; //클릭 감지용 오브젝트
    public GameObject towerObject; //타워 오브젝트
    public Vector3 pos; //벡터 위치

    public GridInfo(int index, bool hasTower, GameObject towerPlace)
    {
        this.index = index;
        this.hasTower = hasTower;
        this.towerPlace = towerPlace;
        this.pos = towerPlace.transform.position;
    }
}
