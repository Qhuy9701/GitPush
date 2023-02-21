using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickBridge : MonoBehaviour
{
    [SerializeField] private GameObject wallcheck;

    void Start()
    {}
    void Update()
    {}


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            wallcheck.SetActive(false);
        }
    }
    private void OnCollisitionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
        }
    }
}
