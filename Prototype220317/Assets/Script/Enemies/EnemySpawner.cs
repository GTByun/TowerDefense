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


    void Start()
    {
        spawnDelay = 0.5f;
    }

    void Update()
    {
        if (true) // ���� ���� ����
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
