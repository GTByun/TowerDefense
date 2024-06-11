using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button Start;
    [SerializeField] private Button Help;
    [SerializeField] private Button Credit;
    [SerializeField] private Button Quit;
    [SerializeField] private Button CreditOff;

    public void GameStart() => SceneManager.LoadScene("GameScene");

    public void GameQuit() => Application.Quit();
}
