using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuickQuit : MonoBehaviour
{
    //상수
    private const float appSpeed = 25f;
    private const float quitTimeSet = 0.8f;
    
    private float quitTime = 0f;
    public GameObject back;
    private Image backImg;
    private TextMeshProUGUI text;
    

    private void Start()
    {
        backImg = back.GetComponent<Image>();
        text = back.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (quitTime > 0)
            {
                Debug.Log("종료");
                Application.Quit();
            }
            else
            {
                quitTime = quitTimeSet;
            }
        }
        if (quitTime > 0)
        {
            quitTime -= Time.deltaTime;
        }
        else
        {
            quitTime = 0;
        }
        byte alpha = (byte)Mathf.Ceil(Mathf.Clamp(-appSpeed * quitTime * (quitTime - quitTimeSet), 0, 1) * 255);
        backImg.color = new Color32(255, 255, 255, alpha);
        text.color = new Color32(0, 0, 0, alpha);
    }
}
