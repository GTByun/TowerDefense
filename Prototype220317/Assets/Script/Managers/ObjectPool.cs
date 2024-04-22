using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab; // ������Ʈ Ǯ�� ������ ������
    public int poolSize; // ������Ʈ Ǯ�� ũ��

    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    // ������Ʈ Ǯ �ʱ�ȭ
    public void InitializePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(objectPrefab, transform);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    // ������Ʈ ��������
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
        // ������Ʈ Ǯ�� ��� ������ ������Ʈ�� ������ ���� ����
        GameObject newObj = Instantiate(objectPrefab, transform);
        objectPool.Add(newObj);
        //newObj.SetActive(true);
        return newObj;
    }

    // ������Ʈ Ǯ�� ������Ʈ ��ȯ
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