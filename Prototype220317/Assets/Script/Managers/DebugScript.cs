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
        //여기에서 outputString 스트링빌더에 Append 해주면 나옴
        outputString.Append("Hello World!\n");
        outputString.Append($"현재 게임 스테이트 : {gameManager.stateManager.gameState}\n");
        outputString.Append($"towerInHand : {gameManager.gridManager.towerInHand}\n");
        outputString.Append($"cardTower : {gameManager.cardManager.cards[0].GetComponent<CardScript>().tower}");
        outputString.Append($" ,{gameManager.cardManager.cards[1].GetComponent<CardScript>().tower}");
        outputString.Append($" ,{gameManager.cardManager.cards[2].GetComponent<CardScript>().tower}\n");
        outputString.Append($"현재 라운드 HP : {Enemy.HPMax}\n");

        for (int i = 0; i < 9; i++)
        {
            outputString.Append(gameManager.gridManager.gridInfoArr[i].towerIndex);
            if (i % 3 == 2) outputString.Append("\n");
        }
        
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
        outputString.Clear();
        BuildString();
        tmp.text = outputString.ToString();
    }
    #endregion
}
