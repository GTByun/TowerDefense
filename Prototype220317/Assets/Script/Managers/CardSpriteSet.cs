using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardSpriteSet : MonoBehaviour
{
    public Image cardIcon;
    public TextMeshProUGUI cardName;
    public TextMeshProUGUI cardDescription;
    private GameManager gameManager;
    public int tower;


    private void Start()
    {
        gameManager = GameManager.instance;
        SetCard(tower);
    }

    public void SetCard(int value)
    {
        tower = value;
        cardName.text = gameManager.TowerInfoManager.GetName(value);
        cardIcon.sprite = gameManager.TowerInfoManager.GetIcon(value);
        cardDescription.text = gameManager.TowerInfoManager.GetDescription(value);
    }

    public void CardClicked()
    {
        gameManager.gridManager.towerInHand = tower;
        gameManager.StateManager.EnterState(GameState.EditMode);
    }
}
