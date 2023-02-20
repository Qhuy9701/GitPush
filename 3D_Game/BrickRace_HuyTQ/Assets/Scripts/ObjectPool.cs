using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToPool;
    [SerializeField] private int amountToPool;
    private List<GameObject>[] pooledObjects;

    private void Start()
    {
        pooledObjects = new List<GameObject>[objectsToPool.Length];

        for (int i = 0; i < objectsToPool.Length; i++)
        {
            pooledObjects[i] = new List<GameObject>();

            for (int j = 0; j < amountToPool; j++)
            {
                GameObject obj = Instantiate(objectsToPool[i]);
                obj.SetActive(false);
                pooledObjects[i].Add(obj);
            }
        }
    }

    public GameObject GetPooledObject(int index)
    {
        for (int i = 0; i < pooledObjects[index].Count; i++)
        {
            if (!pooledObjects[index][i].activeInHierarchy)
            {
                return pooledObjects[index][i];
            }
        }

        GameObject obj = Instantiate(objectsToPool[index]);
        obj.SetActive(false);
        pooledObjects[index].Add(obj);
        return obj;
    }
}
