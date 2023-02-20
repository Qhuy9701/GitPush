using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    public GameObject obstaclePrefab;
    public int poolSize = 10;
    public List<GameObject> pooledObstacles;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        pooledObstacles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(obstaclePrefab);
            obj.SetActive(false);
            pooledObstacles.Add(obj);
        }
    }

    public GameObject GetPooledObstacle()
    {
        for (int i = 0; i < pooledObstacles.Count; i++)
        {
            if (!pooledObstacles[i].activeInHierarchy)
            {
                return pooledObstacles[i];
            }
        }
        GameObject obj = (GameObject)Instantiate(obstaclePrefab);
        obj.SetActive(false);
        pooledObstacles.Add(obj);
        return obj;
    }
}
