using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public static int life;
    public static float damageUpgrade;
    public static float reloadSpeedUpgrade;
    public static int wave;

    public TextMeshProUGUI lifeText;
    public static bool errAd;
    bool hasLife;
    bool debugModOn;
    
    

    private void Start()
    {
        life = 20;
        damageUpgrade = 1f;
        reloadSpeedUpgrade = 1f;
        wave = 0;
        lifeText.text = life.ToString();
        debugModOn = false;
        hasLife = true;
        errAd = false;
    }

    private void Update()
    {
        if (life <= 0 && hasLife)
        {
            if (!debugModOn) GameManager.instance.stateManager.EnterState(GameState.GameOver);
            hasLife = false;
        }
        if (life > 0) 
        {
            hasLife = true;
        }
        lifeText.text = life.ToString();

        if (Input.GetKeyDown(KeyCode.O))
        {
            life--;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            life++;
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Time.timeScale -= 1f;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Time.timeScale += 1f;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            debugModOn = !debugModOn;
            Debug.Log("DebugMode: " + debugModOn.ToString());
        }
    }
}
