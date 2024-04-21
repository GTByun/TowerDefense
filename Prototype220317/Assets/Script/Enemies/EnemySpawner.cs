using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public ObjectPool pool;
    float spawnDelay;
    float timer;
    int spawnCount;
    private GameManager gameManager;


    void Start()
    {
        spawnDelay = 0.5f;
        gameManager = GameManager.instance;
    }

    void Update()
    {
        if (gameManager.stateManager.gameState == GameState.GameMode) // 게임 시작 상태
        {
            timer += Time.deltaTime;
            if (timer > spawnDelay)
            {
                pool.GetObjectFromPool();
                timer = 0;
            }
        }        
    }
}
