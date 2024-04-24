using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool pool;
    public float spawnDelay;
    public float timer;
    public int currentSpawnN;
    public int spawnCount;
    public int wave;

    private GameManager gameManager;
    public static GameObject[] enemies;
    public static int deadEnemy;

    private void Awake()
    {
        spawnCount = 15;
        enemies = new GameObject[spawnCount];
        for (int i = 0; i < spawnCount; i++)
        {
            enemies[i] = pool.GetObjectFromPool();
            enemies[i].SetActive(true);
            enemies[i].name = "enemy" + i;
        }
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
    }

    void Start()
    {
        gameManager = GameManager.instance;
        wave = 0;
        currentSpawnN = 0;
        timer = 0;
        spawnDelay = 1f;        
    }

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
            }
        }
    }
}
