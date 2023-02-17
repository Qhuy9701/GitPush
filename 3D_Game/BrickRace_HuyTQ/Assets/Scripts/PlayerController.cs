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
    [SerializeField] private Brick brickPrefab;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector2 input = new Vector2(joyStick.Horizontal, joyStick.Vertical);

        Vector3 dirMovement = new Vector3(input.x, 0f, input.y);
        Vector3 moveDestination = transform.position + (dirMovement * speed * Time.deltaTime);
        transform.position = moveDestination;
        if (input.sqrMagnitude > 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(input.x, 0, input.y));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Wall"))
        {
            other.transform.SetParent(transform);
            other.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
            numberbrick++;
            Debug.Log(numberbrick);
            foreach (Transform child in transform)
            {
                child.position = new Vector3(transform.position.x + 0.5f, child.position.y + 0.250f, transform.position.z);
                child.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
