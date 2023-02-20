using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float speed = 6;
    [SerializeField] private FixedJoystick joyStick;
    [SerializeField] private int numberbrick;
    [SerializeField] private Transform backPos;
    private float yPos = 0.2f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(joyStick.Horizontal, joyStick.Vertical);

        Vector3 dirMovement = new Vector3(-input.x, 0f, -input.y);
        Vector3 moveDestination = transform.position + (dirMovement * speed * Time.deltaTime);
        transform.position = moveDestination;
        if (input.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(input.x, 0, input.y));
        }
    }

    private void OnTriggerEnter(Collider other)
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
    }
}
