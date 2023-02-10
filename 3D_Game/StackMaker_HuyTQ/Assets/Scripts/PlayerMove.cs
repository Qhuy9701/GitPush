using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] Vector3 startPoint, endPoint;
    [SerializeField] Vector3 direction;
    [SerializeField] int numberbrick = 0;
    [SerializeField] GameObject brickstart;
    [SerializeField] ReadText map;
    public int[,] mapData;

    private void Start()
    {     
        transform.position =  new Vector3(ReadText.startPointX,0, ReadText.startPointZ);    
    }

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {   
            endPoint = Input.mousePosition;
            Vector3 dir = endPoint - startPoint;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            if (angle > -45 && angle < 45)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
            else if (angle > 45 && angle < 135)
            {
                transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
            }
            else if (angle > 135 || angle < -135)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
            else if (angle > -135 && angle < -45)
            {
                transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0))
            {
                startPoint = Input.mousePosition;
            } 
        }
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("brickmove"))
        {  
            other.transform.SetParent(transform);
            other.transform.position = new Vector3(transform.position.x, -0.250f, transform.position.z);       
            numberbrick++;
            Debug.Log(numberbrick);
            foreach (Transform child in transform)
            {
                child.position = new Vector3(child.position.x, child.position.y + 0.250f, child.position.z);                
            }
        }
        if (other.tag.Equals("brickremove"))
        {
            if (numberbrick > 0)
            {
                Destroy(transform.GetChild(numberbrick).gameObject);
                numberbrick--;
                foreach (Transform child in transform)
                {
                    child.position = new Vector3(child.position.x, child.position.y - 0.250f, child.position.z);
                }
                
            }
            Debug.Log(numberbrick);       
        }    
        if (other.tag.Equals("brickstop"))
        {
            foreach (Transform child in transform)
            {
                if (child == transform.GetChild(0))
                {
                    continue;
                }
                Destroy(child.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("brickwall"))
        {
            Debug.Log("wall");
        }
    }
}
