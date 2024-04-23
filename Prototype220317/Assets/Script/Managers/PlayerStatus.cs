using TMPro;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static float EXP;

    public static int Life = 20;
    public TextMeshProUGUI LifeText;
    private void Update()
    {
        LifeText.text=Life.ToString();
    }
}
