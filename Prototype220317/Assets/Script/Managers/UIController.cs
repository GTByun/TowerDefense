using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI를 제어함. 끄고 키고 업데이트하고 하는 메소드를 가지고 잇음
/// </summary>
public class UIController : MonoBehaviour
{
    //인스펙터창 복잡해질거 같아서 헤더 넣어둠
    [Header("검은 화면")]
    [SerializeField] private GameObject darkFader;
    [SerializeField] private GameObject darkFaderEdit;
    [Header("카드 GUI")]
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
    /// 카드 선택 모드 UI
    /// </summary>
    public void CardModeOn()
    {
        darkFader.SetActive(true);
        cards.SetActive(true);
        darkFaderEdit.SetActive(false);
    }
    /// <summary>
    /// 에딧 모드 UI
    /// </summary>
    public void EditModeOn()
    {
        darkFader.SetActive(false);
        cards.SetActive(false);
        darkFaderEdit.SetActive(true);
        UpdateEditModeHUD();
    }
    /// <summary>
    /// 게임모드 UI
    /// </summary>
    public void GameModeOn()
    {
        cards.SetActive(false);
        darkFaderEdit.SetActive(false);
        startButton.SetActive(false);
    }

    /// <summary>
    /// 에딧모드의 화면을 업데이트 해줌
    /// </summary>
    public void UpdateEditModeHUD()
    {
        if (gameManager.stateManager.gameState != GameState.EditMode) return;
        int index = gameManager.gridManager.towerInHand;
        if (index == -1)
        {
            //손에 타워 없음
            towerInHandHUD.SetActive(false);
            startButton.SetActive(true);
            UpdateSplash("");
        }else
        {
            //손에 타워 잇음
            towerInHandHUD.SetActive(true);
            startButton.SetActive(false);
            towerInHandIcon.sprite = gameManager.towerInfoManager.GetIcon(index);
            UpdateSplash("손에 있는 타워를 지우거나 설치하세요 .");
        }
    }

    public void UpdateSplash(string text)
    {
        splashText.text = text;
    }
}
