using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject darkFader;
    public GameObject darkFaderEdit;
    public GameObject cards;

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
    }

    public void GameModeOn()
    {
        cards.SetActive(false);
        darkFaderEdit.SetActive(false);
    }
}
