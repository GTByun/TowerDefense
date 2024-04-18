using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpriteSet : MonoBehaviour
{
    public Image cardIcon;
    public Text cardName;
    public Text cardDescription;
    private TowerInfoManager TIManager;
    private EditManager editManager;
    public int index;


    private void Start()
    {
        TIManager = GameManager.gameManager.TowerInfoManager;
        editManager = GameManager.gameManager.EditManager;
        SetCard(index);
    }

    public void SetCard(int value)
    {
        index = value;
        Debug.Log(TIManager.GetName(value));
        cardName.text = TIManager.GetName(value);
        cardIcon.sprite = TIManager.GetIcon(value);
        cardDescription.text = TIManager.GetDescription(value);
    }

    public void CardClicked()
    {
        editManager.EditTower(index);
    }
}
