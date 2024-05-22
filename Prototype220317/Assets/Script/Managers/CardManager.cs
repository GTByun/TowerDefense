using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public GameObject[] cards;
    public float moduleChance = 0.2f;
    private int nTower;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
        nTower = gameManager.towerInfoManager.nTower;
    }

    public void RandomizeCards()
    {
        int excludeCard = Random.Range(0, nTower / 2);
        int newCard = 0;
        foreach (var card in cards)
        {
            if (newCard == excludeCard) newCard++;
            if (gameManager.gridManager.HasTower(newCard) != -1 && Random.Range(0f, 1f) < moduleChance) //���� �̹� �� Ÿ���� ������ �ְ�, Ȯ���� �ȴٸ� ��� Ÿ���� ��� ī�忡 ������
            {
                newCard += nTower / 2;
            }
            card.GetComponent<CardScript>().SetCard(newCard);
            newCard++;
        }
    }
}
