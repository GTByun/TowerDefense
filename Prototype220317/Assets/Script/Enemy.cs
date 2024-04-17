using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoint;
    public bool burning;
    public float burningDamage;
    private float timer = 0.0f;

    void Start()
    {
        
    }

    void Update()
    {
        if (burning)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                healthPoint -= burningDamage;
                Debug.Log(burningDamage+"burn");
                timer = 0.0f;
            }
        }
    }

    public void Hit(float damage)
    {
        Debug.Log(damage + "hit");
    }
    public void Burn(float damage)
    {
        burning = true;
        burningDamage=burningDamage > damage? burningDamage:damage;
    }
}
