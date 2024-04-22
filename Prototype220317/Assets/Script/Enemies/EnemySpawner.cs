using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool pool;
    float spawnDelay;
    float timer;
    int currentSpawn;
    int spawnCount;
    private GameManager gameManager;
    public static GameObject[] enemies;

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
        currentSpawn = 0;
        timer = 0;
        spawnDelay = 1f;        
    }

    void Update()
    {
        if (gameManager.stateManager.gameState == GameState.GameMode) // 게임 시작 상태
        {
            if (currentSpawn < spawnCount)
            {
                timer += Time.deltaTime;
                if (timer > spawnDelay)
                {
                    enemies[currentSpawn++].SetActive(true);
                    timer = 0;
                }
            }            
        }        
    }
}
