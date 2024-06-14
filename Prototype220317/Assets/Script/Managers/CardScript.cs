using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


/// <summary>
/// ī�忡�� ���� ��ũ��Ʈ��
/// </summary>
public class CardScript : MonoBehaviour
{
    public Image cardIcon; //ī���� ������
    public TextMeshProUGUI cardName; //ī���� �̸�
    public TextMeshProUGUI cardDescription; //ī���� 
    public int tower; //�� Ÿ���� ����Ű�� Ÿ�� �ε���
    private GameManager gameManager;
    private Animator animator;
    // public CardScript otherCard0;
    // public CardScript otherCard1;
    public CardScript[] othercards;


    private void Start()
    {
        animator = GetComponent<Animator>();
        gameManager = GameManager.instance;
    }

    /// <summary>
    /// �� ī�尡 ����Ű�� Ÿ���� ������
    /// </summary>
    /// <param name="value">������ Ÿ���� �ε���</param>
    public void SetCard(int value)
    {
        tower = value;
        UpdateCard();
    }
    /// <summary>
    /// ī���� ������ ���� �ε����� �°� ������Ʈ��
    /// </summary>
    public void UpdateCard()
    {
        gameManager = GameManager.instance;
        cardName.text = gameManager.towerInfoManager.GetName(tower);
        cardIcon.sprite = gameManager.towerInfoManager.GetIcon(tower);
        cardDescription.text = gameManager.towerInfoManager.GetDescription(tower);
    }
    /// <summary>
    /// �� ī�尡 Ŭ���Ǿ��� �� ȣ���
    /// </summary>
    public void CardClicked()
    {
        if (gameManager.gridManager.towerInHand != -1) return; //�տ� Ÿ���� �ִٸ�, ī�� Ŭ���� �����մϴ�
        gameManager.gridManager.SetHand(tower);
        gameManager.gridManager.CheckModule(tower);
        animator.SetTrigger("CardShrinkTrigger");
        Invoke("TriggerOtherCard", 0.5f);
    }
    public void ThrowState()
    {
        gameManager.stateManager.BumpCard();
    }
    public void TriggerOtherCard()
    {
        foreach (var card in othercards)
        {
            card.animator.SetTrigger("CardShrinkTrigger");
        }
        //otherCard0.animator.SetTrigger("CardShrinkTrigger");
        //otherCard1.animator.SetTrigger("CardShrinkTrigger");
    }
    public void DamageUp()
    {
        gameManager.playerStatus.damageUpgrade += 0.1f;
        gameManager.playerStatus.damageUpText.text = gameManager.playerStatus.damageUpgrade * 100 + " %";
        animator.SetTrigger("CardShrinkTrigger");
        Invoke("TriggerOtherCard", 0.5f);
    }
    public void SpeedUp()
    {
        gameManager.playerStatus.speedUpgrade += 0.1f;
        gameManager.playerStatus.speedUpText.text = gameManager.playerStatus.speedUpgrade * 100 + " %";
        animator.SetTrigger("CardShrinkTrigger");
        Invoke("TriggerOtherCard", 0.5f);
    }
}
