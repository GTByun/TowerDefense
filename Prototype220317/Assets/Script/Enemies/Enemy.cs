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
    //����Ʈ ������ enemyData�� �����صΰ�, ������ ���ư��� ������ ������ ���⼭ �����մϴ�.
    public float hp;//���� ���� ü���Դϴ�.
    public bool burning;//���� ��Ÿ�� �ִ����� �����Դϴ�.
    public float speed;//���� �̵� �ӵ��Դϴ�.

    public static float hpMultiplier = 1f;//ü���� ����Դϴ�. �ִ� ü�¿� �������ϴ�.
    public static float burningDamage;//ȭ�� �����Դϴ�.

    /* Technical Private */
    private EnemyType enemyType;//���� Ÿ���Դϴ�.
    private EnemyData enemyData;//���� enemyData�Դϴ�.
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
            // ���
            DeSpawn();
            gameManager.enemyKilled++;
            GameObject corpse = gameManager.deadPool.GetObjectFromPool();
            corpse.transform.position = transform.position;
            corpse.SetActive(true);
            // ����ġ
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
                        // ����
                        DeSpawn();
                        // ������ ����
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
    /// ���ο� EnemyData�� �޾Ƽ� �� Enemy�� ������ ���� ��ü�մϴ�.
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
