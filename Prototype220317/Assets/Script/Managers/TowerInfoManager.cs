using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//각 타워에 대한 정보를 가지고 있는 TowerInfo를 전체적으로 관리함
public class TowerInfoManager : MonoBehaviour 
{
    //TowerInfo의 배열
    public TowerInfo[] TowerInfoArr = new TowerInfo[8];

    
    public GameObject GetObject(int index) //받은 인덱스값에 해당하는 타워의 프리팹을 리턴함
    {
        return TowerInfoArr[index].TowerObject;
    }
    public Sprite GetIcon(int index) //받은 인덱스값에 해당하는 타워의 아이콘을 리턴함
    {
        return TowerInfoArr[index].TowerIcon;
    }
    public string GetName(int index) //받은 인덱스값에 해당하는 타워의 이름을 리턴함
    {
        return TowerInfoArr[index].TowerName;
    }
    public string GetDescription(int index) //받은 인덱스값에 해당하는 타워의 설명을 리턴함
    {
        return TowerInfoArr[index].TowerDescription;
    }
}



[System.Serializable] //TowerInfo의 정보들을 인스펙터창에서 수정 가능하도록 설정
public class TowerInfo //하나의 타워에 대한 모든 정보를 보관함
{
    //타워의 아이콘, 이름, 설명, 프리팹

    public Sprite TowerIcon;
    public string TowerName;
    public string TowerDescription;
    public GameObject TowerObject;
}
