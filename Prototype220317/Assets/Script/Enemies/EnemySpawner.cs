using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// EnemySpawner�� ���̺꿡�� ���� ������ �����մϴ�.
/// ���̺꿡 ���� ���� ���ϰ�, ���� ��������, ���̺��� ���� �˸��� ���� ����� �����ϴ�.
/// </summary>

public class EnemySpawner : MonoBehaviour
{
    /*
    public float spawnDelay;
    public float timer;
    public int currentSpawnN;
    public int spawnCount;
    public int wave;
    public int point;
    public TextMeshProUGUI waveStartTxt;

    public static int deadEnemy;
    */
    [Header("Stats")]
    public int point = 0; //���� ����Ʈ. ����Ʈ�� Ŭ���� EnemySpawner�� ���̺꿡 �� ���� ���� �����մϴ�
    public int wave = 1; //���̺� ��
    [Range(0, 3)]
    public int specialDistribution = 0; //�󸶳� ���� Ư�� �� ������ ����ϴ����� ��. 0�Ͻ� Ư�� ���� �������� �ʽ��ϴ�.

    private float spawnDelay = 0; //���� ���� ���ö����� �ɸ��� �ð��Դϴ�.

    public static List<GameObject> enemies; //������ ���� ����Ʈ�Դϴ�. Ÿ���� ���� ���� ���� üũ�ϱ� ���� �������� �����մϴ�.
    public static Queue<EnemyType> waveEnemy; //���� ���̺꿡 ���� ������ ���� Queue�Դϴ�. Queue Ŭ������ ����ϱ⿡ ���� ������� ���� ���� ���ɴϴ�.
    [Header("Technical")]
    public ObjectPool pool;//�� ������Ʈ�� Pool�Դϴ�.
    [SerializeField] private List<EnemyData> enemiesData;//��ũ���ͺ� ������Ʈ EnemyData�� ���� ������ �ִ� ����Ʈ�Դϴ�.
    private GameManager gameManager;
    void Start()
    {
        gameManager = GameManager.instance;
        enemies = new List<GameObject>();
        waveEnemy = new Queue<EnemyType>();
        //currentSpawnN = 0;
        //timer = 0;
    }

    /// <summary>
    /// ���̺긦 �����մϴ�.
    /// </summary>
    public void StartWave()
    {
        BuyWave();
        StartCoroutine("WaveCoroutine");
    }

    /// <summary>
    /// �̹� ���̺꿡�� ���� ������ �����մϴ�.
    /// �ϴ��� �׳� ���� ���� 15�� �ֽ��ϴ�.
    /// </summary>
    public void BuyWave()
    {
        waveEnemy.Clear();
        
        for(int i = 0; i < 15; i++)
        {
            waveEnemy.Enqueue(EnemyType.Normal);
        }
    }

    /// <summary>
    /// ���̺긦 �����մϴ�. �ڷ�ƾ�� ���鼭 �ֱ������� ���� �����մϴ�. waveEmemy�� ����ִٸ� �ڷ�ƾ�� �����մϴ�.
    /// </summary>
    public IEnumerator WaveCoroutine()
    {
        while (true) {
            if (waveEnemy.Count == 0)
            {
                Debug.Log("n");
                yield break;
            }
            else
            {
                Debug.Log("y");
            yield return new WaitForSeconds(spawnDelay);
            }
            SpawnNextEnemy();
        }
    }

    /// <summary>
    /// ���� ���� �����մϴ�.
    /// </summary>
    public void SpawnNextEnemy()
    {
        EnemyData nextEnemyData = enemiesData[(int)waveEnemy.Dequeue()];//waveEnemy���� ������ ���� ���� �����ɴϴ�.
        GameObject obj = pool.GetObjectFromPool();//Ǯ���� ���ӿ�����Ʈ�� ������ �˸��� EnemyData�� ����ְ� �ʱ�ȭ�մϴ�.
        obj.GetComponent<Enemy>().ResetData(nextEnemyData);
        obj.SetActive(true);
        enemies.Add(obj);//���� ���� ���� enemies ���� ����Ʈ�� �߰��մϴ�.
        spawnDelay = nextEnemyData.spawnDelay;//���� ���� �����ϱ���� �ɸ��� �ð��� �����մϴ�.
    }
    /*

    

    void Update()
    {
        if (gameManager.stateManager.gameState == GameState.GameMode) // ���� ���� ����
        {
            if (currentSpawnN < spawnCount)
            {
                timer += Time.deltaTime;
                if (timer > spawnDelay)
                {
                    Enemy enemy = enemies[currentSpawnN].GetComponent<Enemy>();
                    enemy.setHP(wave);
                    enemies[currentSpawnN++].SetActive(true);
                    timer = 0;
                }
            }
            else if (deadEnemy >= spawnCount) // ���̺� ����
            {
                GameManager.instance.stateManager.EnterState(GameState.SelectReward); 
                deadEnemy = 0;
                currentSpawnN = 0;
                wave++;
                waveStartTxt.text = $"WAVE {wave+1} Start";
            }
        }
    }
    */
}
