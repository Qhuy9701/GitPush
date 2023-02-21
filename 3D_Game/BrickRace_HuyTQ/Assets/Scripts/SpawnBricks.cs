using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBricks : MonoBehaviour
{
    public GameObject[] brickPrefabs; // Mảng chứa các Prefab brick có màu khác nhau
    public int numRows; // Số hàng
    public int numCols; // Số cột
    public float xOffset; // Khoảng cách giữa các cột
    public float zOffset; // Khoảng cách giữa các hàng

    void Start()
    {
        // Tính toán số lượng brick cần spawn cho mỗi loại
        int numBricksPerType = numRows * numCols / brickPrefabs.Length;

        // Khởi tạo biến đếm số lượng brick đã spawn cho mỗi loại là 0
        Dictionary<GameObject, int> brickCount = new Dictionary<GameObject, int>();
        foreach (GameObject brickPrefab in brickPrefabs)
        {
            brickCount[brickPrefab] = 0;
        }

        // Spawn bricks
        Vector3 spawnPos = transform.position;
        int numBricksSpawned = 0;
        int numBricksToSpawn = numBricksPerType * brickPrefabs.Length;
        while (numBricksSpawned < numBricksToSpawn)
        {
            // Lấy ngẫu nhiên prefab brick từ mảng
            GameObject brickPrefab = brickPrefabs[Random.Range(0, brickPrefabs.Length)];

            // Kiểm tra số lượng brick đã spawn của loại này, nếu đã đủ thì chuyển sang loại khác
            if (brickCount[brickPrefab] >= numBricksPerType)
            {
                continue;
            }

            // Spawn brick
            GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);

            // Đếm số lượng brick đã spawn cho loại này và tăng biến đếm tổng số lượng brick đã spawn lên 1
            brickCount[brickPrefab]++;
            numBricksSpawned++;

            // Di chuyển spawnPos đến vị trí của cột tiếp theo
            spawnPos.x += xOffset;

            // Nếu đã spawn đủ số lượng brick cho một hàng, chuyển xuống hàng tiếp theo và reset vị trí cột
            if (numBricksSpawned % numCols == 0)
            {
                spawnPos.x = transform.position.x;
                spawnPos.z += zOffset;
            }
        }
    }
}
