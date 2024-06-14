using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

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
    
    //각 등급마다 얼마나 다양하게 적을 쓸 수 있는지입니다. n이면 n 종류의 적만 사용하며, 단 한 종류만 원하면 1을 하면 됩니다.
    [SerializeField][Range(0, 5)] private int commonSpawn = 1;
    [SerializeField][Range(0, 4)] private int uncommonSpawn = 0;
    [SerializeField][Range(0, 3)] private int specialSpawn = 0;

    private float spawnDelay = 0; //다음 적이 나올때까지 걸리는 시간입니다.

    public static List<GameObject> enemies; //적들의 정적 리스트입니다. 타워가 범위 내의 적을 체크하기 위해 정적으로 선언합니다.
    public static Queue<EnemyType> waveEnemy; //현재 웨이브에 나올 적들의 정적 Queue입니다. Queue 클래스를 사용하기에 먼저 집어넣은 적이 먼저 나옵니다.
    GameManager gameManager;
    [Header("Technical")]
    public ObjectPool pool;//적 오브젝트의 Pool입니다.
    [SerializeField] private List<EnemyData> enemiesData;//스크립터블 오브젝트 EnemyData를 전부 가지고 있는 리스트입니다.
    private int commonCount, uncommonCount, specialCount;//각 등급별로 적이 얼마나 있는지의 값입니다.
    void Start()
    {
        gameManager = GameManager.instance;
        enemies = new List<GameObject>();
        waveEnemy = new Queue<EnemyType>();
        SetGradeCount();
    }

    /// <summary>
    /// 웨이브를 시작합니다.
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
    /// 이번 웨이브에서 나올 적들을 구매합니다.
    /// 일단은 그냥 보통 적을 15번 넣습니다.
    /// </summary>
    private void BuyWave()
    {
        waveEnemy.Clear();
        int currentPoint = point;//이번 웨이브에서 사용할 포인트입니다.
        
        //이번 웨이브에서 사용될 적을 추려냅니다. 적이 너무 다양하게 나오지 않도록 전체 적 Pool 중에서 몇몇만 사용하는 방식입니다.
        List<EnemyType> thisWaveType = new List<EnemyType>();
        for (int i = 0; i < specialSpawn; i++) //Special 적을 뽑아내는 중
        {
            thisWaveType.Add(enemiesData[Random.Range(commonCount + uncommonCount, specialCount + commonCount + uncommonCount)].type);
        }
        for (int i = 0; i < uncommonSpawn; i++) //Uncommon 적을 뽑아내는 중
        {
            thisWaveType.Add(enemiesData[Random.Range(commonCount, commonCount + uncommonCount)].type);
        }
        for (int i = 0; i < commonSpawn; i++) //Common 적을 뽑아내는 중
        {
            thisWaveType.Add(enemiesData[Random.Range(0, commonCount)].type);
        }

        //추려낸 적 종류를 이용해 웨이브를 생성합니다.
        //웨이브를 짜는 방법은 두 가지가 있습니다.
        //첫번째로 무작위를 계속 돌려서 적을 구매합니다.
        while (thisWaveType.Count > 0)//thisWaveType이 비어있다면 탈출합니다.
        {
            EnemyType target = thisWaveType[Random.Range(0, thisWaveType.Count)];
            if (enemiesData[(int) target].price > currentPoint) //만약 구매할 점수가 없다면, 구매하지 않고 thisWaveType에서 제거하여 앞으로 구매하지 않도록 합니다.
            {
                thisWaveType.Remove(target);
                continue;
            }
            else//구매할 점수가 있다면, 점수를 차감하고 이번 웨이브에 추가합니다.
            {
                currentPoint -= enemiesData[(int)target].price;
                waveEnemy.Enqueue(target);
            }
        }
        //두번째로 Special 적을 집중 구매합니다. Special이 있을때만 낮은 확률로 사용하며, 적 분포중 대부분이 Special이 됩니다.
        //일단 미구현

    }

    /// <summary>
    /// 웨이브를 시작합니다. 코루틴을 돌면서 주기적으로 적을 생성합니다. waveEmemy가 비어있다면 코루틴을 종료합니다.
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
    /// 웨이브에 따라 체력의 배수를 정합니다.
    /// </summary>
    /// <param name="wave">현재 웨이브</param>
    private void SetHP(int wave)
    {
        Enemy.hpMultiplier = Mathf.Pow(1.4f, gameManager.playerStatus.wave);
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

    /// <summary>
    /// Enemie Data에서 각 등급별로 적이 얼마나 준비되어있는지 계산해 Count에 넣습니다.
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
