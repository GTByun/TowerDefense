using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public static int life = 20;
    public static float damageUpgrade = 1f;
    public TextMeshProUGUI lifeText;
    public bool hasLife;

    private void Start()
    {
        hasLife = true;
        lifeText.text = life.ToString();
    }

    private void Update()
    {
        if (life <= 0 && hasLife)
        {
            GameManager.instance.stateManager.EnterState(GameState.GameOver);
            hasLife = false;
        }
        if (life > 0) 
        {
            hasLife = true;
        }
        lifeText.text = life.ToString();
        if(Input.GetKeyDown(KeyCode.O))
        {
            life--;
        }
    }
}
