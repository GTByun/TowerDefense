using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    private GameObject nowTower;
    private int towerId;
    private EditManager editManager;
    private TowerInfoManager towerInfoManager;

    private void Awake()
    {
        towerId = -1;
    }

    private void Start()
    {
        editManager = GameManager.instance.EditManager;
        towerInfoManager = GameManager.instance.TowerInfoManager;
    }

    private void OnMouseDown()
    {
        if (editManager.isEdit)
        {

        }
    }
}
