using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float speed = 20f;
    [SerializeField] Vector3 startPoint, endPoint;
    [SerializeField] Vector3 direction;
    [SerializeField] int numberbrick = 0;
    [SerializeField] bool isMoving = false;
    [SerializeField] bool isTouch;

    private void Start()
    {
        transform.position = new Vector3(ReadText.startPointX, 0, ReadText.startPointZ);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startPoint = Input.mousePosition;
            isTouch = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isTouch = false;    
        }

        if (isTouch)
        {
            Move();
        }

        if (isMoving)
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void Move()
    {
        endPoint = Input.mousePosition;
        Vector3 dir = endPoint - startPoint;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle > -45 && angle < 45)
        {
            direction = new Vector3(-1, 0, 0);
            isMoving = true;
        }
        else if (angle > 45 && angle < 135)
        {
            direction = new Vector3(0, 0, -1);
            isMoving = true;
        }
        else if (angle > 135 || angle < -135)
        {
            direction = new Vector3(1, 0, 0);
            isMoving = true;
        }
        else if (angle > -135 && angle < -45)
        {
            direction = new Vector3(0, 0, 1);
            isMoving = true;
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
                Destroy(transform.GetChild(numberbrick - 0).gameObject);
                numberbrick--;
                foreach (Transform child in transform)
                {
                    child.position = new Vector3(child.position.x, child.position.y - 0.250f, child.position.z);
                }
            }
            Destroy(other.gameObject);

            //if numberbrick = 0 load menu lose game
            if (numberbrick == 0)
            {
                Application.LoadLevel("MenuWinGame");
            }
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
            Application.LoadLevel("MenuWinGame");
        }      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("brickwall"))
        {
            
        }
        if(collision.gameObject.tag.Equals("brickwallcheck"))
        {
            //set is moving = false
            isMoving = false;
            Debug.Log("brickwallcheck");
        }
    }
}


