using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [Range(1, 10)]
    public int width, height;
    Vector3 origin;
    int randomValue;
    public GameObject[] cubes;
    private List<Vector3> eatenPositions = new List<Vector3>();

    void Start()
    {
        SpawnCubes();
    }

    void SpawnCubes()
    {
        for (int i = -5; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                randomValue = Random.Range(0, 3);
                origin = new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j);
                GameObject obj = Instantiate(cubes[randomValue], origin, transform.rotation, transform);
            }
        }
    }

    void SpawnNewCube(Vector3 position)
    {
        // Lấy tất cả các vị trí còn trống
        List<Vector3> availablePositions = new List<Vector3>();
        for (int i = -5; i < width; i++)
        {
            for (int j = -4; j < height; j++)
            {
                Vector3 pos = new Vector3(transform.position.x + i, transform.position.y, transform.position.z + j);
                if (!eatenPositions.Contains(pos))
                {
                    availablePositions.Add(pos);
                }
            }
        }

        // Nếu có vị trí còn trống thì tạo viên gạch mới
        if (availablePositions.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            GameObject obj = Instantiate(cubes[randomValue], availablePositions[randomIndex], transform.rotation, transform);
        }
    }

    void AddEatenPosition(Vector3 position)
    {
        eatenPositions.Add(position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cube"))
        {
            if (!eatenPositions.Contains(other.transform.position))
            {
                AddEatenPosition(other.transform.position);
                Destroy(other.gameObject, 5f);
                Invoke("SpawnNewCube", 5f);
            }
        }
    }
}
