using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;

/// <summary>
/// ����� UI�� ������ ǥ����
/// </summary>
public class DebugScript : MonoBehaviour
{
    private void BuildString()
    {

    }
    #region �������
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
