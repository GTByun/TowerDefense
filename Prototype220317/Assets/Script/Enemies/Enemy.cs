using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Image image;

    private float timer = 0.0f;
    private float modular;

    private EnemyMove move;
    //
    //
    //

    [Header("Stats")]
    //디폴트 스탯은 enemyData가 저장해두고, 게임이 돌아가는 동안의 스탯은 여기서 관리합니다.
    public float hp;//적의 현재 체력입니다.
    public bool burning;//적이 불타고 있는지의 여부입니다.
    public float speed;//적의 이동 속도입니다.

    public static float hpMultiplier = 1f;//체력의 배수입니다. 최대 체력에 곱해집니다.
    public static float burningDamage;//화상 피해입니다.

    /* Technical Private */
    private EnemyType enemyType;//적의 타입입니다.
    private EnemyData enemyData;//적의 enemyData입니다.
    private GameManager gameManager;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        move = EnemyMove.Up;
        gameManager = GameManager.instance;
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        image.fillAmount = hp / (enemyData.hp * hpMultiplier);
        if (hp <= 0)
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
                hp -= burningDamage;
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
        EnemySpawner.enemies.Remove(gameObject);
    }
    public void Hit(float damage)
    {
        hp -= damage;
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

    /// <summary>
    /// 새로운 EnemyData를 받아서 이 Enemy의 스탯을 전부 교체합니다.
    /// </summary>
    /// <param name="nextEnemyData"></param>
    public void ResetData(EnemyData nextEnemyData)
    {
        enemyData = nextEnemyData;
        hp = enemyData.hp * hpMultiplier;
        speed = enemyData.speed;
        spriteRenderer.sprite = enemyData.sprite;
    }
}
