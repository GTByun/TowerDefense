using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI�� ������. ���� Ű�� ������Ʈ�ϰ� �ϴ� �޼ҵ带 ������ ����
/// </summary>
public class UIController : MonoBehaviour
{
    //�ν�����â ���������� ���Ƽ� ��� �־��
    [Header("���� ȭ��")]
    [SerializeField] private GameObject darkFader;
    [SerializeField] private GameObject darkFaderEdit;
    [Header("ī�� GUI")]
    [SerializeField] private GameObject cards;
    [Header("HUD")]
    [SerializeField] private GameObject towerInHandHUD;
    [SerializeField] private Image towerInHandIcon;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI splashText;
    [SerializeField] private Material tile;

    public float speed = 1f;

    private float offset = 0;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        offset += Time.deltaTime;
        tile.SetTextureOffset("_MainTex", new Vector2(0, offset) * speed);
    }

    /// <summary>
    /// ī�� ���� ��� UI
    /// </summary>
    public void CardModeOn()
    {
        darkFader.SetActive(true);
        cards.SetActive(true);
        darkFaderEdit.SetActive(false);
    }
    /// <summary>
    /// ���� ��� UI
    /// </summary>
    public void EditModeOn()
    {
        darkFader.SetActive(false);
        cards.SetActive(false);
        darkFaderEdit.SetActive(true);
        UpdateEditModeHUD();
    }
    /// <summary>
    /// ���Ӹ�� UI
    /// </summary>
    public void GameModeOn()
    {
        cards.SetActive(false);
        darkFaderEdit.SetActive(false);
        startButton.SetActive(false);
    }

    /// <summary>
    /// ��������� ȭ���� ������Ʈ ����
    /// </summary>
    public void UpdateEditModeHUD()
    {
        if (gameManager.stateManager.gameState != GameState.EditMode) return;
        int index = gameManager.gridManager.towerInHand;
        if (index == -1)
        {
            //�տ� Ÿ�� ����
            towerInHandHUD.SetActive(false);
            startButton.SetActive(true);
            UpdateSplash("");
        }else
        {
            //�տ� Ÿ�� ����
            towerInHandHUD.SetActive(true);
            startButton.SetActive(false);
            towerInHandIcon.sprite = gameManager.towerInfoManager.GetIcon(index);
            UpdateSplash("�տ� �ִ� Ÿ���� ����ų� ��ġ�ϼ��� .");
        }
    }

    public void UpdateSplash(string text)
    {
        splashText.text = text;
    }
}
