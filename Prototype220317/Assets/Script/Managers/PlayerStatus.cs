using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public static float EXP;

    public static int Life = 20;
    public TextMeshProUGUI LifeText;

    private void Start()
    {
        LifeText.text = Life.ToString();
    }

    private void Update()
    {
        if (Life == 0)
        {
            GameManager.instance.stateManager.EnterState(GameState.GameOver);
        }
        LifeText.text = Life.ToString();
        if(Input.GetKeyDown(KeyCode.O))
        {
            Life--;
        }
    }
}
