using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// TowerPlace에 들어가는 스크립트이며 단순히 클릭 이벤트만 들어가있음
/// </summary>
public class TowerPlace : MonoBehaviour
{
    private GridManager gridManager;
    public int towerIndex; //이 타워의 인덱스

    private void Start()
    {
        gridManager = GameManager.instance.gridManager;
    }

    private void OnMouseDown()
    {
        Debug.Log("towerIndex : "+towerIndex);
        //클릭 감지. 뭔 클릭인지 신경안씀. 일단 내 index가 클릭되었다고 함수 호출함
        gridManager.GridClicked(towerIndex);
    }
}
