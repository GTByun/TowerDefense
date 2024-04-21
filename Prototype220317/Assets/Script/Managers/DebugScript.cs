using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

/// <summary>
/// 디버그 UI에 정보를 표시함
/// </summary>
public class DebugScript : MonoBehaviour
{
    private void BuildString()
    {

    }
    #region 구성요소
    private GameManager gameManager;
    [SerializeField] private TextMeshProUGUI tmp;

    StringBuilder outputString = new StringBuilder();

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        UpdateDebugUI();
    }

    private void UpdateDebugUI()
    {
        BuildString();
        tmp.text = outputString.ToString();
    }
    #endregion
}
