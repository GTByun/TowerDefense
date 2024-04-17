using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    public GameObject bulletObject;
    public int poolSize;
    public static Queue<GameObject> bulletObjectPool;
    // Start is called before the first frame update
    void Start()
    {
        bulletObjectPool = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(bulletObject);
            bulletObjectPool.Enqueue(obj);
            obj.SetActive(false);
        }
    }
    public static void BulletEnqueue(GameObject obj)
    {
        bulletObjectPool.Enqueue(obj);
    }
    public static GameObject BulletDequeue()
    {
        return bulletObjectPool.Dequeue();
    }
}
