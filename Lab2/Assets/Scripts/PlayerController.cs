using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private bool FacingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * Time.DeltaTime * speed, rb.velocity.y);   
        if (move > 0 && !FacingRight)
        {   
            Flip();
        }
        else if (move < 0 && FacingRight)
        {                  
            Flip();
        }
        anim.SetFloat("Speed", Mathf.Abs(move));
    }
}
