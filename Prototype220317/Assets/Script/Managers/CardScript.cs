using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// 카드에게 들어가는 스크립트임
/// </summary>
public class CardScript : MonoBehaviour
{
    public Image cardIcon; //카드의 아이콘
    public TextMeshProUGUI cardName; //카드의 이름
    public TextMeshProUGUI cardDescription; //카드의 
    public int tower; //이 타워가 가리키는 타워 인덱스
    private GameManager gameManager;


    private void Start()
    {
        gameManager = GameManager.instance;
        SetCard(tower);
    }

    /// <summary>
    /// 이 카드가 가리키는 타워를 변경함
    /// </summary>
    /// <param name="value">변경할 타워의 인덱스</param>
    public void SetCard(int value)
    {
        tower = value;
        UpdateCard();
    }
    /// <summary>
    /// 카드의 정보를 현재 인덱스에 맞게 업데이트함
    /// </summary>
    public void UpdateCard()
    {

        cardName.text = gameManager.towerInfoManager.GetName(tower);
        cardIcon.sprite = gameManager.towerInfoManager.GetIcon(tower);
        cardDescription.text = gameManager.towerInfoManager.GetDescription(tower);
    }
    /// <summary>
    /// 이 카드가 클릭되었을 때 호출됨
    /// </summary>
    public void CardClicked()
    {
        gameManager.gridManager.SetHand(tower);
        gameManager.stateManager.EnterState(GameState.EditMode);
    }
}
