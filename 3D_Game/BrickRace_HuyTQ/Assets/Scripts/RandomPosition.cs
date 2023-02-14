using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition: MonoBehaviour
{
    public List<Transform> positions = new List<Transform>();
    public GameObject prefab;

    private List<Transform> usedPositions = new List<Transform>();

    private void Start()
    {
        // Fill the positions list with objects that have the Transform component.
        foreach (Transform child in transform)
        {
            positions.Add(child);
        }

        for (int i = 0; i < 5; i++)
        {
            // Choose a random position from the positions list.
            int randomIndex = Random.Range(0, positions.Count);
            Transform randomPosition = positions[randomIndex];

            // Make sure the same position is not used more than once.
            if (!usedPositions.Contains(randomPosition))
            {
                usedPositions.Add(randomPosition);
                Instantiate(prefab, randomPosition.position, Quaternion.identity);
            }
            else
            {
                // If the chosen position is already used, decrease the counter and try again.
                i--;
            }
        }
    }
}
