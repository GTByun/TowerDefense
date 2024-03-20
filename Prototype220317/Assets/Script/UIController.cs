using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject darkFader;
    public GameObject firstCard;
    public GameObject darkFaderEdit;
    
    public void DarkFaderOn(bool active)
    {
        darkFader.SetActive(active);
    }

    public void FirstCardOn(bool active)
    {
        firstCard.SetActive(active);
    }

    public void DarkFaderEditOn(bool active)
    {
        darkFaderEdit.SetActive(active);
    }
}
