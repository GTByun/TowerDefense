using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthPoint;
    public bool burning;
    public float burningDamage;

    private float timer = 0.0f;
    public float speedMagni;
    public float speed;
    private float synthSpeed;
    private float modular;


    private EnemyMove move;

    public float Speed { set => speed = value; }

    private void Awake()
    {
        move = EnemyMove.Up;
    }

    private void OnEnable()
    {
        modular = GameManager.gameManager.modular;
        healthPoint = 100;
        transform.position = new Vector2(modular * -2, modular * -2);
        move = EnemyMove.Up;
        synthSpeed = speedMagni * speed;
        Debug.Log("spawn");
    }



    private void Start()
    {
    }

    private void Update()
    {
        if(healthPoint <= 0)
        {
            //사망
            DeSpawn();
            PlayerStatus.exp += 10;
            if(PlayerStatus.exp >= 100 )
            {
                //레벨업
                PlayerStatus.exp = PlayerStatus.exp - 100;
            }
        }
        if (burning)
        {
            timer += Time.deltaTime;
            if (timer >= 1.0f)
            {
                healthPoint -= burningDamage;
                Debug.Log(burningDamage + "burn");
                timer = 0.0f;
            }
        }

        if (true)//GameManager.gameManager.GameOn)
        {
            switch (move)
            {            
                case EnemyMove.Left:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.left);
                    if (transform.position.x <= modular * - 2 + modular / 5 * 4)
                    {
                        DeSpawn();
                        // 라이프 감소
                        Debug.Log("-life");
                    }
                    break;
                case EnemyMove.Down:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.down);
                    if (transform.position.y <= modular * -2)
                    {
                        transform.position = new Vector2(transform.position.x, modular * -2);
                        move = EnemyMove.Left;
                    }
                    break;
                case EnemyMove.Right:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.right);
                    if (transform.position.x >= modular * 2)
                    {
                        transform.position = new Vector2(modular * 2, transform.position.y);
                        move = EnemyMove.Down;
                    }
                    break;
                case EnemyMove.Up:
                    transform.Translate(synthSpeed * Time.deltaTime * Vector2.up);
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
        Debug.Log("despawn");
        gameObject.SetActive(false);
        transform.position = new Vector2(modular * -2, modular * -2);
        EnemySpawner.enemys.Enqueue(gameObject);
    }
    public void Hit(float damage)
    {
        healthPoint -= damage;
    }
    public void Burn(float damage)
    {
        burning = true;
        burningDamage=burningDamage > damage? burningDamage:damage;
    }
}
