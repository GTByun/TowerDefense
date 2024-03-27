using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardSpriteSet : MonoBehaviour
{
    public Image image;
    public Text description;
    public Text imageDescription;
    private CardSpriteInfoSaver cardSpriteInfoSaver;
    private EditManager editManager;
    public int firstId;
    private int nowId;

    private void Start()
    {
        cardSpriteInfoSaver = GameManager.gameManager.cardSpriteInfoSaver;
        editManager = GameManager.gameManager.editManager;
        SetCardSprite(firstId);
    }

    public void SetCardSprite(int id)
    {
        image.sprite = cardSpriteInfoSaver.images[id];
        description.text = cardSpriteInfoSaver.decription[id];
        imageDescription.text = cardSpriteInfoSaver.imageDescription[id];
        nowId = id;
    }

    public void SendId()
    {
        editManager.editId = nowId;
        editManager.isEdit = true;
    }
}
