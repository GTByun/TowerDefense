using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public void GameStart() => SceneManager.LoadScene("GameScene");

    public void GameQuit() => Application.Quit();
}
