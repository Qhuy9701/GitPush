using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] Vector3 startPoint, endPoint;
    [SerializeField] Vector3 direction;
    [SerializeField] GameObject brickadd;
    [SerializeField] int numberbrick = 2;
    [SerializeField] GameObject brickstart;

    public int[,] mapData;

    private void Start()
    {  
    
        transform.position =  new Vector3(ReadText.startPointX, 0, ReadText.startPointZ);    
        //if the character gets a brick, push the character position up       
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
                transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);//direction = Vector3.down;
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("brickmove"))
        {  
            Destroy(other.gameObject);
            GameObject newBrickAdd = Instantiate(brickadd);
            newBrickAdd.transform.SetParent(transform);
            newBrickAdd.transform.position = new Vector3(transform.position.x, -1f+numberbrick*-0.5f, transform.position.z);       
            numberbrick++;
            Debug.Log(numberbrick);
            foreach (Transform child in transform)
            {
                child.position = new Vector3(child.position.x, child.position.y + 0.5f, child.position.z);                
            }
            //if player get a brick, push the player up
           
        }
        
        

        if (other.tag.Equals("brickremove"))
        {
            if (numberbrick > 2)
            {
                Destroy(transform.GetChild(numberbrick - 2).gameObject);
                numberbrick--;
                foreach (Transform child in transform)
                {
                    child.position = new Vector3(child.position.x, child.position.y - 0.5f, child.position.z);
                }
            }
            Debug.Log(numberbrick);
           
        }

        
        if (other.tag.Equals("brickstop"))
        {
            //delte all brick chirldren
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
                //debug
                Debug.Log("Delete all brick");
            }
        }
    }
}
