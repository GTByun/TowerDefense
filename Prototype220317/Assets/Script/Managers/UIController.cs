using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("검은 화면")]
    [SerializeField] private GameObject darkFader;
    [SerializeField] private GameObject darkFaderEdit;
    [Header("카드 GUI")]
    [SerializeField] private GameObject cards;
    [Header("HUD")]
    [SerializeField] private GameObject towerInHandHUD;
    [SerializeField] private Image towerInHandIcon;
    [SerializeField] private GameObject startButton;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
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
        UpdateEditModeHUD();
    }

    public void GameModeOn()
    {
        cards.SetActive(false);
        darkFaderEdit.SetActive(false);
    }

    public void UpdateEditModeHUD()
    {
        int index = gameManager.gridManager.towerInHand;
        if (index == -1)
        {
            //손에 타워 없음
            towerInHandHUD.SetActive(false);
            startButton.SetActive(true);
        }else
        {
            //손에 타워 잇음
            towerInHandHUD.SetActive(true);
            startButton.SetActive(false);
            towerInHandIcon.sprite = gameManager.TowerInfoManager.GetIcon(index);
        }
    }
}
