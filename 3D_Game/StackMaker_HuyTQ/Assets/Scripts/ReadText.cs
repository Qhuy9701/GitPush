using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadText : MonoBehaviour
{
    public static int Row;
    public static int Column;
    public static int[,] MapData;
    //input game object 
    public GameObject brickmove;
    public GameObject brickwall;
    public GameObject brickremove;
    public GameObject brickstart;
    public GameObject brickstop;

    public static float startPointX, startPointY , startPointZ;

    private void Awake()
    {
        // Load file text "Map/Map1"
        string text = Resources.Load<TextAsset>("Map/Map1").text;

        // Split text by line break "\r\n"
        string[] lines = text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);

        // Set number of rows and columns in map data
        Row = lines.Length;
        Column = lines[0].Split(',').Length;

        // Initialize map data with size of rows and columns
        MapData = new int[Row, Column];

        // Loop through each line and split line by comma to get map data for each cell
        for (int i = 0; i < Row; i++)
        {
            string[] line = lines[i].Split(',');
            for (int j = 0; j < Column; j++)
            {
                MapData[i, j] = int.Parse(line[j]);
            }
        }

        //render map 1 with object and 0 wwith object0
        for (int i = 0; i < Row; i++)
        {
            for (int j = 0; j < Column; j++)
            {
                if (MapData[i, j] == 1)
                {
                    Instantiate(brickmove, new Vector3(j, 0, i), Quaternion.identity);
                }
                else if (MapData[i, j] == 2)
                {
                    Instantiate(brickremove, new Vector3(j, 0, i), Quaternion.identity);
                }
                else if (MapData[i, j] == 3)
                {
                    Instantiate(brickstart, new Vector3(j, 0, i), Quaternion.identity);
                    startPointX = j;
                 
                    startPointZ = i;
                }
                else if (MapData[i, j] == 4)
                {
                    Instantiate(brickstop, new Vector3(j, 0, i), Quaternion.identity);
                }
                else
                {
                    Instantiate(brickwall, new Vector3(j, 0, i), Quaternion.identity);
                }
            }
        }
    }
}