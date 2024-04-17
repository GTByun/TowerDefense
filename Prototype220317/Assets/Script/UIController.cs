using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject darkFader;
    public GameObject firstCard;
    public GameObject darkFaderEdit;
    public GameObject cards;

    private void Awake()
    {
        darkFader.SetActive(true);
        firstCard.SetActive(true);
        darkFaderEdit.SetActive(false);
        cards.SetActive(false);
    }

    public void CardModeOn()
    {
        darkFader.SetActive(true);
        cards.SetActive(true);
        darkFaderEdit.SetActive(false);
    }

    public void EditModeOn()
    {
        darkFader.SetActive(false);
        cards.SetActive(false);
        darkFaderEdit.SetActive(true);
        firstCard.SetActive(false);
    }

    public void GameModeOn()
    {
        cards.SetActive(false);
        darkFaderEdit.SetActive(false);
    }
}
