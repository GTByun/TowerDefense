using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public static float HPMax;
    public float HP;
    public bool burning;
    public float burningDamage;

    public Image image;

    private float timer = 0.0f;
    public float speed;
    private float modular;

    private GameManager gameManager;
    private EnemyMove move;

    private void Awake()
    {
        move = EnemyMove.Up;
        gameManager = GameManager.instance;
    }

    private void OnEnable()
    {
        modular = GameManager.instance.modular;
        if (gameManager.stateManager.gameState == GameState.GameMode) transform.position = new Vector2(modular * -2, modular * -2);
        else transform.position = new Vector2(15, 0);
        move = EnemyMove.Up;
        
    }

    private void Start()
    {
    }

    private void Update()
    {
        image.fillAmount = HP / HPMax;
        if (HP <= 0)
        {
            // 사망
            DeSpawn();
            gameManager.enemyKilled++;
            GameObject corpse = gameManager.deadPool.GetObjectFromPool();
            corpse.transform.position = transform.position;
            corpse.SetActive(true);
            // 경험치
        }
        if (burning)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                HP -= burningDamage;
                timer = 0.0f;
            }
        }

        if (gameManager.stateManager.gameState == GameState.GameMode)
        {
            switch (move)
            {            
                case EnemyMove.Left:
                    transform.Translate(speed * Time.deltaTime * Vector2.left);
                    if (transform.position.x <= modular * - 2 + modular / 5 * 4)
                    {
                        // 골인
                        DeSpawn();
                        // 라이프 감소
                        PlayerStatus.Life--;
                    }
                    break;
                case EnemyMove.Down:
                    transform.Translate(speed * Time.deltaTime * Vector2.down);
                    if (transform.position.y <= modular * -2)
                    {
                        transform.position = new Vector2(transform.position.x, modular * -2);
                        move = EnemyMove.Left;
                    }
                    break;
                case EnemyMove.Right:
                    transform.Translate(speed * Time.deltaTime * Vector2.right);
                    if (transform.position.x >= modular * 2)
                    {
                        transform.position = new Vector2(modular * 2, transform.position.y);
                        move = EnemyMove.Down;
                    }
                    break;
                case EnemyMove.Up:
                    transform.Translate(speed * Time.deltaTime * Vector2.up);
                    if (transform.position.y >= modular * 2)
                    {
                        transform.position = new Vector2(transform.position.x, modular * 2);
                        move = EnemyMove.Right;
                    }
                    break;
            }
        }
    }

    private void DeSpawn()
    {
        gameObject.SetActive(false);
        EnemySpawner.deadEnemy++;
    }
    public void Hit(float damage)
    {
        HP -= damage;
    }
    public void Burn(float damage)
    {
        burning = true;
        burningDamage=burningDamage > damage? burningDamage:damage;
    }
    public void SlowDown(float slowScale)
    {
        speed = slowScale;
    }

    internal void setHP(int wave)
    {
        HP = 100f*Mathf.Pow(1.5f,wave);
        HPMax = HP;
    }
}
