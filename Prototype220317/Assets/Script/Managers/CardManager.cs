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
        foreach (var card in cards)
        {
            int newCard = Random.Range(0, nTower / 2);
            if (gameManager.gridManager.HasTower(newCard) != -1 && Random.Range(0f, 1f) < moduleChance) //���� �̹� �� Ÿ���� ������ �ְ�, Ȯ���� �ȴٸ� ��� Ÿ���� ��� ī�忡 ������
            {
                newCard += nTower / 2;
            }
            card.GetComponent<CardScript>().SetCard(newCard);
        }
    }
}
