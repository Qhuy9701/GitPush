using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] protected int numberbrick;
    [SerializeField] protected float speed = 6;
    [SerializeField] protected Transform backPos;
    [SerializeField] private bool isBot;
    private float yPos = 0.2f;
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(IsHaveBrick())
        {
            if(collision.gameObject.CompareTag("Obstacle"))
            {
                //remove object wwith tag bridgeCheck
                Destroy(GameObject.FindWithTag("BridgeCheck"));
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {   
        if(isBot)
        {
            if (other.gameObject.CompareTag("Obstacle2"))
            {
                AddBack(other.gameObject);
            }

            if (other.gameObject.CompareTag("Bridge"))
            {
                Bridge(other.gameObject);
            }
        }
        else
        {
            if (other.gameObject.CompareTag("Obstacle"))
            {
                AddBack(other.gameObject);
            }

            if (other.gameObject.CompareTag("Bridge"))
            {
                Bridge(other.gameObject);
            }
        }
    }

    private void Bridge(GameObject bridgeObj)
    {
        if (backPos.transform.childCount > 0)
        { 
            MeshRenderer mesh = bridgeObj.GetComponent<MeshRenderer>();
            mesh.enabled = true;
            mesh.material.color = Color.red;
            int obstacleNumber = backPos.transform.childCount - 1;
            Destroy(backPos.GetChild(obstacleNumber).gameObject);
    
            yPos -= 0.2f;
            bridgeObj.GetComponent<BoxCollider>().enabled = false;
        }
  
    }
    private void AddBack(GameObject obj)
    {
        obj.transform.SetParent(backPos.transform);
      
        obj.transform.rotation = backPos.rotation;
       
        obj.transform.position = new Vector3(backPos.position.x,yPos,backPos.position.z);
      
        yPos += 0.2f;

        numberbrick++;       
    }

    private bool IsHaveBrick()
    {
        return numberbrick > 0;
    }
}
