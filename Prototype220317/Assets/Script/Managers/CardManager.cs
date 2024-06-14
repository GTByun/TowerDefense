using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] towerCards;
    public GameObject[] upCards;
    private float moduleChance;


    private int nDefaultTower;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        nDefaultTower = gameManager.towerInfoManager.nDefaultTower;
    }

    public void RandomizeCards()
    {
        // 모듈찬스 점점 오르게
        if (gameManager.playerStatus.wave < 6)
        {
            moduleChance = 0.2f;
        }
        else if (gameManager.playerStatus.wave >= 10)
        {
            moduleChance = 0.7f;
            foreach (var card in upCards)
            {
                card.gameObject.SetActive(true);
            }
            gameManager.uiController.AppendUpgradePanel();
        }
        else
        {
            moduleChance = 0.4f;
        }
        int excludeCard = Random.Range(0, nDefaultTower);
        int newCard = 0;
        foreach (var card in towerCards)
        {
            if (newCard == excludeCard) newCard++;
            if (gameManager.gridManager.HasTower(newCard) != -1 && Random.Range(0f, 1f) < moduleChance) //만약 이미 이 타워를 가지고 있고, 확률이 된다면 모듈 타워를 대신 카드에 저장함
            {
                int upgradeNo = Random.Range(1, 3);
                card.GetComponent<CardScript>().SetCard(newCard + nDefaultTower * upgradeNo);
            }else
            {
                card.GetComponent<CardScript>().SetCard(newCard);
            }
            
            newCard++;
        }
    }
}
