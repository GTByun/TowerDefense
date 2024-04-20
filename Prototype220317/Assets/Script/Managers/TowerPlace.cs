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
    public int towerIndex;

    private void Start()
    {
        gridManager = GameManager.instance.gridManager;
    }

    private void OnMouseDown()
    {
        gridManager.TowerClicked(towerIndex);
    }
}
