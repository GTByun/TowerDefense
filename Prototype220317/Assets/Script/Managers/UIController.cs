using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

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
    [SerializeField] private UnityEngine.UI.Image towerInHandIcon;
    [SerializeField] private GameObject startButton;
    [SerializeField] private TextMeshProUGUI splashText;
    [SerializeField] private Material tile;
    [SerializeField] public GameObject gameOver;
    [SerializeField] private TextMeshProUGUI enemyKilledText;
    [SerializeField] private TextMeshProUGUI timePlayedText;
    [SerializeField] private GameObject adBtn;
    [SerializeField] private GameObject creditBtn;
    [Header("광고 에러용")]
    [SerializeField] public GameObject resumeBtn;
    //[SerializeField] public TextMeshProUGUI errTxt;
    public float speed = 1f;

    private float offset = 0;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.instance;
#if UNITY_EDITOR
        creditBtn.SetActive(true);
#endif
    }

    private void Update()
    {
        offset += Time.deltaTime;
        tile.SetTextureOffset("_MainTex", new Vector2(0, offset) * speed);
        if (gameManager.stateManager.gameState == GameState.None) gameOver.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        tile.SetTextureOffset("_MainTex", new Vector2(0, 0));
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
        darkFader.SetActive(false);
        gameOver.SetActive(false); 
    }
    public void GameOverOn()
    {
        adBtn.SetActive(true);
        Debug.Log("GameOverOn");
        darkFader.SetActive(true);
        gameOver.SetActive(true);
        enemyKilledText.text = $"처치한 적 : {gameManager.enemyKilled.ToString()} 마리";
        int hour, minute, second, played;
        played = (int) gameManager.timePlayed;
        hour = played / 3600;
        minute = played / 60;
        second = played % 60;
        timePlayedText.text = $"플레이 시간 : ";
        if (hour != 0) timePlayedText.text += $"{hour}시간 ";
        if (minute != 0) timePlayedText.text += $"{minute}분 ";
        timePlayedText.text += $"{second}초 ";
    }
    public void ResetUI()
    {
        darkFader.SetActive(true);
        gameOver.SetActive(false);

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
