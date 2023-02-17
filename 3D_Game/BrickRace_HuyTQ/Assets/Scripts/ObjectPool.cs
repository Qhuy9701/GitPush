using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Brick brickPrefab;
    public List<Brick> brickList = new List<Brick>();

    public void InitializePool(int numBricks)
    {
        for (int i = 0; i < numBricks; i++)
        {
            Brick brick = Instantiate(brickPrefab);
            brick.gameObject.SetActive(false);
            brickList.Add(brick);
            brick.transform.parent = transform;
        }
    }

    public Brick GetObjectFromPool()
    {
        foreach (Brick brick in brickList)
        {
            if (!brick.gameObject.activeInHierarchy)
            {
                brick.gameObject.SetActive(true);
                return brick;
            }
        }

        Brick newBrick = Instantiate(brickPrefab);
        newBrick.gameObject.SetActive(true);
        brickList.Add(newBrick);
        newBrick.transform.parent = transform;
        return newBrick;
    }
}
