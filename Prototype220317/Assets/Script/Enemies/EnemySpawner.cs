using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
    
    //�� ��޸��� �󸶳� �پ��ϰ� ���� �� �� �ִ����Դϴ�. n�̸� n ������ ���� ����ϸ�, �� �� ������ ���ϸ� 1�� �ϸ� �˴ϴ�.
    [SerializeField][Range(0, 5)] private int commonSpawn = 1;
    [SerializeField][Range(0, 4)] private int uncommonSpawn = 0;
    [SerializeField][Range(0, 3)] private int specialSpawn = 0;

    private float spawnDelay = 0; //���� ���� ���ö����� �ɸ��� �ð��Դϴ�.

    public static List<GameObject> enemies; //������ ���� ����Ʈ�Դϴ�. Ÿ���� ���� ���� ���� üũ�ϱ� ���� �������� �����մϴ�.
    public static Queue<EnemyType> waveEnemy; //���� ���̺꿡 ���� ������ ���� Queue�Դϴ�. Queue Ŭ������ ����ϱ⿡ ���� ������� ���� ���� ���ɴϴ�.
    GameManager gameManager;
    [Header("Technical")]
    public ObjectPool pool;//�� ������Ʈ�� Pool�Դϴ�.
    [SerializeField] private List<EnemyData> enemiesData;//��ũ���ͺ� ������Ʈ EnemyData�� ���� ������ �ִ� ����Ʈ�Դϴ�.
    private int commonCount, uncommonCount, specialCount;//�� ��޺��� ���� �󸶳� �ִ����� ���Դϴ�.
    void Start()
    {
        gameManager = GameManager.instance;
        enemies = new List<GameObject>();
        waveEnemy = new Queue<EnemyType>();
        SetGradeCount();
    }

    /// <summary>
    /// ���̺긦 �����մϴ�.
    /// </summary>
    public void StartWave()
    {
        if (gameManager.playerStatus.wave == 0) gameManager.uiController.AppendUpgradePanel();
        SetHP(gameManager.playerStatus.wave);
        gameManager.playerStatus.wave++;
        point += (int) (gameManager.playerStatus.wave * 1.5f);
        BuyWave();
        StartCoroutine("WaveCoroutine");
    }

    /// <summary>
    /// �̹� ���̺꿡�� ���� ������ �����մϴ�.
    /// �ϴ��� �׳� ���� ���� 15�� �ֽ��ϴ�.
    /// </summary>
    private void BuyWave()
    {
        waveEnemy.Clear();
        int currentPoint = point;//�̹� ���̺꿡�� ����� ����Ʈ�Դϴ�.
        
        //�̹� ���̺꿡�� ���� ���� �߷����ϴ�. ���� �ʹ� �پ��ϰ� ������ �ʵ��� ��ü �� Pool �߿��� �� ����ϴ� ����Դϴ�.
        List<EnemyType> thisWaveType = new List<EnemyType>();
        for (int i = 0; i < specialSpawn; i++) //Special ���� �̾Ƴ��� ��
        {
            thisWaveType.Add(enemiesData[Random.Range(commonCount + uncommonCount, specialCount + commonCount + uncommonCount)].type);
        }
        for (int i = 0; i < uncommonSpawn; i++) //Uncommon ���� �̾Ƴ��� ��
        {
            thisWaveType.Add(enemiesData[Random.Range(commonCount, commonCount + uncommonCount)].type);
        }
        for (int i = 0; i < commonSpawn; i++) //Common ���� �̾Ƴ��� ��
        {
            thisWaveType.Add(enemiesData[Random.Range(0, commonCount)].type);
        }

        //�߷��� �� ������ �̿��� ���̺긦 �����մϴ�.
        //���̺긦 ¥�� ����� �� ������ �ֽ��ϴ�.
        //ù��°�� �������� ��� ������ ���� �����մϴ�.
        while (thisWaveType.Count > 0)//thisWaveType�� ����ִٸ� Ż���մϴ�.
        {
            EnemyType target = thisWaveType[Random.Range(0, thisWaveType.Count)];
            if (enemiesData[(int) target].price > currentPoint) //���� ������ ������ ���ٸ�, �������� �ʰ� thisWaveType���� �����Ͽ� ������ �������� �ʵ��� �մϴ�.
            {
                thisWaveType.Remove(target);
                continue;
            }
            else//������ ������ �ִٸ�, ������ �����ϰ� �̹� ���̺꿡 �߰��մϴ�.
            {
                currentPoint -= enemiesData[(int)target].price;
                waveEnemy.Enqueue(target);
            }
        }
        //�ι�°�� Special ���� ���� �����մϴ�. Special�� �������� ���� Ȯ���� ����ϸ�, �� ������ ��κ��� Special�� �˴ϴ�.
        //�ϴ� �̱���

    }

    /// <summary>
    /// ���̺긦 �����մϴ�. �ڷ�ƾ�� ���鼭 �ֱ������� ���� �����մϴ�. waveEmemy�� ����ִٸ� �ڷ�ƾ�� �����մϴ�.
    /// </summary>
    public IEnumerator WaveCoroutine()
    {
        while (true) {
            if (waveEnemy.Count == 0)
            {
                yield break;
            }
            else
            {
                yield return new WaitForSeconds(spawnDelay);
            }
            SpawnNextEnemy();
        }
    }
    /// <summary>
    /// ���̺꿡 ���� ü���� ����� ���մϴ�.
    /// </summary>
    /// <param name="wave">���� ���̺�</param>
    private void SetHP(int wave)
    {
        Enemy.hpMultiplier = Mathf.Pow(1.4f, gameManager.playerStatus.wave);
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

    /// <summary>
    /// Enemie Data���� �� ��޺��� ���� �󸶳� �غ�Ǿ��ִ��� ����� Count�� �ֽ��ϴ�.
    /// </summary>
    private void SetGradeCount()
    {
        for (int i = 0; i < enemiesData.Count; i++)
        {
            switch (enemiesData[i].grade)
            {
                case EnemyGrade.Common:
                    commonCount++;
                    break;
                case EnemyGrade.Uncommon:
                    uncommonCount++;
                    break;
                case EnemyGrade.Special:
                    specialCount++;
                    break;
                case EnemyGrade.Boss:
                    break;
            }
        }
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
