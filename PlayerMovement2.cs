using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{


    public float speed = 4;
    public float jumpForce = 550;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    //[HideInInspector]
    //public bool LookingRight = true;

    private Rigidbody2D rb2d;
    private Animator anim;

    private bool isGrounded = false;
    private bool jump = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
       // anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown("space") && isGrounded)
        {
            jump = true;
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //anim.SetFloat("Speed", Mathf.Abs(moveHorizontal));

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        /*if ((moveHorizontal > 0 && !LookingRight)||(moveHorizontal < 0 && LookingRight))
        {
            Flip ();
        }*/

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1F, whatIsGround);

        if (jump && isGrounded)
        {
            rb2d.AddForce(new Vector3(0, jumpForce, 0));
            jump = false;
        }
    }

    /*public void Flip()
    {
        LookingRight = !LookingRight;
        Vector3 myScale = transform.localScale;
        myScale.x *= -1;
        transform.localScale = myScale;

    }*/
}
