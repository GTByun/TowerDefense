using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab; // 오브젝트 풀에 저장할 프리팹
    public int poolSize; // 오브젝트 풀의 크기

    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    // 오브젝트 풀 초기화
    public void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    // 오브젝트 가져오기
    public GameObject GetObjectFromPool()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                //obj.SetActive(true);
                return obj;
            }
        }
        // 오브젝트 풀에 사용 가능한 오브젝트가 없으면 새로 생성
        GameObject newObj = Instantiate(objectPrefab, transform);
        objectPool.Add(newObj);
        //newObj.SetActive(true);
        return newObj;
    }

    // 오브젝트 풀로 오브젝트 반환
    public void ReturnObjectToPool(GameObject obj)
    {
        if (objectPool.Contains(obj))
        {
            obj.SetActive(false);
        }
        else
        {
            Destroy(obj);
        }
    }
}