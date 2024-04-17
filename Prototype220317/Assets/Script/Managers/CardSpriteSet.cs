using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpriteSet : MonoBehaviour
{
    public Image image;
    public Text description;
    public Text imageDescription;
    private TowerInfoManager TIManager;
    private EditManager editManager;
    public int firstId;
    public int nowId;


    private void Start()
    {
        TIManager = GameManager.gameManager.TowerInfoManager;
        editManager = GameManager.gameManager.EditManager;
        SetCardSprite(firstId);
    }

    public void SetCardSprite(int id)
    {
        image.sprite = TIManager.GetIcon(id);
        description.text = TIManager.GetName(id);
        imageDescription.text = TIManager.GetDescription(id);
        nowId = id;
    }

    public void SendId()
    {
        editManager.SetEditId(nowId);
        editManager.SetEditMode(true);
    }
}
