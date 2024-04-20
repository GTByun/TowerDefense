using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 각 타워에 대한 정보를 가지고 있는 TowerInfo를 전체적으로 관리함
/// </summary>
public class TowerInfoManager : MonoBehaviour 
{
    //TowerInfo의 배열
    public TowerInfo[] TowerInfoArr = new TowerInfo[8];

    /// <summary>
    /// 받은 인덱스값에 해당하는 타워의 프리팹을 리턴함
    /// </summary>
    public GameObject GetObject(int index) 
    {
        return TowerInfoArr[index].towerObject;
    }
    /// <summary>
    /// 받은 인덱스값에 해당하는 타워의 아이콘을 리턴함
    /// </summary>
    public Sprite GetIcon(int index)
    {
        return TowerInfoArr[index].towerIcon;
    }
    /// <summary>
    /// 받은 인덱스값에 해당하는 타워의 이름을 리턴함
    /// </summary>
    public string GetName(int index)
    {
        return TowerInfoArr[index].towerName;
    }
    /// <summary>
    /// 받은 인덱스값에 해당하는 타워의 설명을 리턴함
    /// </summary>
    public string GetDescription(int index) 
    {
        return TowerInfoArr[index].towerDescription;
    }
}



