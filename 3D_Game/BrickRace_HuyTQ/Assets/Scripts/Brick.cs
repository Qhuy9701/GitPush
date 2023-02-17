using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public BrickType type;

    public enum BrickType
    {
        Red,
        Blue,
        Yellow,
        Black,
    }

    public void OnInit()
    {
        switch (type)
        {
            case BrickType.Red:
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case BrickType.Blue:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case BrickType.Yellow:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case BrickType.Black:
                GetComponent<Renderer>().material.color = Color.black;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            gameObject.SetActive(false);
            Invoke("GetObjectFromPool", 1f);
        }
    }
}
