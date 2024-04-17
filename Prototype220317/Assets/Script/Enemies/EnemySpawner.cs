using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    float spawnDelay;
    float timer;
    public static Queue<GameObject> enemys;
    int spawnCount;

    void Start()
    {
        spawnDelay = 0.5f;
        enemys = new Queue<GameObject>();
        for (int i = 0; i < 30; i++)
        {
            GameObject en= Instantiate(enemy);
            en.SetActive(false);
            en.transform.SetParent(transform);
            enemys.Enqueue(en);
        }
    }
    void Update()
    {
        if (GameManager.gameManager.GameOn)
        {
            timer += Time.deltaTime;
            if (timer > spawnDelay)
            {
                Debug.Log(enemys.Count);
                GameObject en = SpawnEnemy();
                en.SetActive(true);
                timer = 0;
            }
        }        
    }

    private GameObject SpawnEnemy()
    {
        GameObject en;
        if (enemys.Count <= 0)
        {
            en = Instantiate(enemy);
            en.SetActive(false);
            en.transform.SetParent(transform);
            enemys.Enqueue(en);
        }
        else
        {
            Debug.Log("dequeue");
            en= enemys.Dequeue();
        }
        return en;
    }
}
