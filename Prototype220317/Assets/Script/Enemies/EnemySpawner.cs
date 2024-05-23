using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// EnemySpawner는 웨이브에서 나올 적들을 관리합니다.
/// 웨이브에 나올 적을 정하고, 적을 내보내며, 웨이브의 끝을 알리는 등의 기능을 가집니다.
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
    public int point = 0; //현재 포인트. 포인트가 클수록 EnemySpawner가 웨이브에 더 많은 적을 구매합니다
    public int wave = 1; //웨이브 수
    [Range(0, 3)]
    public int specialDistribution = 0; //얼마나 많은 특수 적 종류를 허용하는지의 값. 0일시 특수 적을 구매하지 않습니다.

    private float spawnDelay = 0; //다음 적이 나올때까지 걸리는 시간입니다.

    public static List<GameObject> enemies; //적들의 정적 리스트입니다. 타워가 범위 내의 적을 체크하기 위해 정적으로 선언합니다.
    public static Queue<EnemyType> waveEnemy; //현재 웨이브에 나올 적들의 정적 Queue입니다. Queue 클래스를 사용하기에 먼저 집어넣은 적이 먼저 나옵니다.
    [Header("Technical")]
    public ObjectPool pool;//적 오브젝트의 Pool입니다.
    [SerializeField] private List<EnemyData> enemiesData;//스크립터블 오브젝트 EnemyData를 전부 가지고 있는 리스트입니다.
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
    /// 웨이브를 시작합니다.
    /// </summary>
    public void StartWave()
    {
        BuyWave();
        StartCoroutine("WaveCoroutine");
    }

    /// <summary>
    /// 이번 웨이브에서 나올 적들을 구매합니다.
    /// 일단은 그냥 보통 적을 15번 넣습니다.
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
    /// 웨이브를 시작합니다. 코루틴을 돌면서 주기적으로 적을 생성합니다. waveEmemy가 비어있다면 코루틴을 종료합니다.
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
    /// 다음 적을 스폰합니다.
    /// </summary>
    public void SpawnNextEnemy()
    {
        EnemyData nextEnemyData = enemiesData[(int)waveEnemy.Dequeue()];//waveEnemy에서 다음에 나올 적을 가져옵니다.
        GameObject obj = pool.GetObjectFromPool();//풀에서 게임오브젝트를 가져와 알맞은 EnemyData를 집어넣고 초기화합니다.
        obj.GetComponent<Enemy>().ResetData(nextEnemyData);
        obj.SetActive(true);
        enemies.Add(obj);//새로 만든 적을 enemies 정적 리스트에 추가합니다.
        spawnDelay = nextEnemyData.spawnDelay;//다음 적을 스폰하기까지 걸리는 시간을 지정합니다.
    }
    /*

    

    void Update()
    {
        if (gameManager.stateManager.gameState == GameState.GameMode) // 게임 시작 상태
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
            else if (deadEnemy >= spawnCount) // 웨이브 종료
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
