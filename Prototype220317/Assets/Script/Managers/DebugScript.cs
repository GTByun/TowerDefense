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
        //���⿡�� outputString ��Ʈ�������� Append ���ָ� ����
        outputString.Append("Hello World!\n");
        outputString.Append($"���� ���� ������Ʈ : {gameManager.stateManager.gameState}\n");
        outputString.Append($"towerInHand : {gameManager.gridManager.towerInHand}");
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
        outputString.Clear();
        BuildString();
        tmp.text = outputString.ToString();
    }
    #endregion
}
