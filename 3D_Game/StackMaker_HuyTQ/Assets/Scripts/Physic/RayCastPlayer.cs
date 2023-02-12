using UnityEngine;

public class RayCastPlayer : MonoBehaviour
{
    public bool isbrickwall = false;
    public float distance = 0.25f;
    
    private void Update()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == "brickwall")
            {
                isbrickwall = true;
            }
            else
            {
                isbrickwall = false;
            }
        }
    }

    public void RaycastLeftBrick()
    {
        transform.Rotate(0, -90, 0);
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == "brickwall")
            {
                isbrickwall = true;
            }
            else
            {
                isbrickwall = false;
            }
        }
        transform.Rotate(0, 90, 0);
    }

    public void RaycastRightBrick()
    {
        transform.Rotate(0, 90, 0);
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == "brickwall")
            {
                isbrickwall = true;
            }
            else
            {
                isbrickwall = false;
            }
        }
        transform.Rotate(0, -90, 0);
    }

    public void RaycastBackBrick()
    {
        transform.Rotate(0, 180, 0);
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == "brickwall")
            {
                isbrickwall = true;
            }
            else
            {
                isbrickwall = false;
            }
        }
        transform.Rotate(0, -180, 0);
    }

    public void RaycastFrontBrick()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            if (hit.collider.gameObject.tag == "brickwall")
            {
                isbrickwall = true;
            }
            else
            {
                isbrickwall = false;
            }
        }
    }

}
