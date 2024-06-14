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
        // ������� ���� ������
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
            if (gameManager.gridManager.HasTower(newCard) != -1 && Random.Range(0f, 1f) < moduleChance) //���� �̹� �� Ÿ���� ������ �ְ�, Ȯ���� �ȴٸ� ��� Ÿ���� ��� ī�忡 ������
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
