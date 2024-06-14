using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStatus : MonoBehaviour
{
    public int life;
    public float damageUpgrade;
    public float reloadSpeedUpgrade;
    public int wave;

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
        lifeText.text = life.ToString();
        if (life <= 0 && hasLife)
        {
            if (!debugModOn) GameManager.instance.stateManager.EnterState(GameState.GameOver);
            hasLife = false;
        }
        if (life > 0) 
        {
            hasLife = true;
        }
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
