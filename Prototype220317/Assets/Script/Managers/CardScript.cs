using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
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


    private void Start()
    {
        gameManager = GameManager.instance;
        SetCard(tower);
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

        cardName.text = gameManager.towerInfoManager.GetName(tower);
        cardIcon.sprite = gameManager.towerInfoManager.GetIcon(tower);
        cardDescription.text = gameManager.towerInfoManager.GetDescription(tower);
    }
    /// <summary>
    /// �� ī�尡 Ŭ���Ǿ��� �� ȣ���
    /// </summary>
    public void CardClicked()
    {
        gameManager.gridManager.SetHand(tower);
        gameManager.stateManager.EnterState(GameState.EditMode);
    }
}
