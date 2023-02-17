using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBlock : MonoBehaviour
{
    [SerializeField] private BoxCollider border;
    [SerializeField] private Brick brickPrefab;
    [SerializeField] private List<Brick> listBlock;

    private void Start()
    {
        CreateBlock();
    }

    private void CreateBlock()
    {
        for (int i = (int)border.bounds.min.x; i < (int)border.bounds.max.x; i++)
        {
            for (int j = (int)border.bounds.min.z; j < (int)border.bounds.max.z; j++)
            {
                //random color 
                int randomType = Random.Range(2, 6);
                Brick brick = Instantiate(brickPrefab, new Vector3(i, 0, j), Quaternion.identity);
                brick.type = (Brick.BrickType)randomType;
                brick.OnInit();
                listBlock.Add(brick);
            }
        }
    }

    public IEnumerator SpawnBlockRandom()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, listBlock.Count);
            Brick brick = listBlock[randomIndex];
            if (brick != null)
            {
                brick.gameObject.SetActive(true);
                listBlock.RemoveAt(randomIndex);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}