using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject credit;
    [SerializeField] private GameObject help;
    [SerializeField] private bool creditComplete = false;
    [SerializeField] private bool helpComplete = false;

    private void Start()
    {
        credit.SetActive(creditComplete);
        help.SetActive(helpComplete);
#if UNITY_EDITOR
        credit.SetActive(true);
        help.SetActive(true);
#endif
    }

    public void GameStart() => SceneManager.LoadScene("GameScene");

    public void GameQuit() => Application.Quit();
}
