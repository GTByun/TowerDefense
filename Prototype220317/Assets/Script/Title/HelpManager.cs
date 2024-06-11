using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class HelpFrame
{
    public GameObject helpScreen;
    public string topTitle;
}

public class HelpManager : MonoBehaviour
{
    [SerializeField] private RectTransform backgroundWindow;
    [SerializeField] private GameObject prevButton;
    [SerializeField] private GameObject nextButton;
    [SerializeField] private TextMeshProUGUI topTitle;
    public HelpFrame[] helpFrames;
    private int page = 0;

    void Update()
    {
        float ratio = (Screen.width * 1.0f) / (Screen.height * 1.0f) * 1080;
        ratio *= 0.8f;
        backgroundWindow.sizeDelta = new Vector2(ratio, 864);
    }

    public void PageUp()
    {
        page++;
    }

    public void PageDown() 
    {
        page--;
    }

    public void PageReset()
    {
        page = 0;
    }

    public void PageSetting()
    {
        for (int i = 0; i < helpFrames.Length; i++) 
        {
            helpFrames[i].helpScreen.SetActive(false);
        }
        helpFrames[page].helpScreen.SetActive(true);
        topTitle.text = helpFrames[page].topTitle;
        prevButton.SetActive(true);
        nextButton.SetActive(true);
        if (page == 0)
        {
            prevButton.SetActive(false);
        }
        if (page == helpFrames.Length - 1)
        {
            nextButton.SetActive(false);
        }
    }
}
