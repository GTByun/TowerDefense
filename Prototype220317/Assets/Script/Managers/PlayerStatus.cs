using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public static int Life = 20;
    public static float damageUpgrade = 1f;
    public TextMeshProUGUI LifeText;

    private void Start()
    {
        LifeText.text = Life.ToString();
    }

    private void Update()
    {
        if (Life <= 0)
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
