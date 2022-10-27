using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTesting : MonoBehaviour
{
    public Rigidbody2D theRB;

    public float moveSpeed, jumpForce;

    public Transform groundCheckPoint;

    public LayerMask whatisGround;
    public bool isGrounded;

    public Animator anim;

    public Transform wallGrabPoint;
    private bool canGrab, isGrabbing;
    private float gravityStore;
    public float wallJumpTime = .2f;
    private float wallJumpCounter;



    // Start is called before the first frame update
    void Start()
    {
        gravityStore = theRB.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(wallJumpCounter <= 0){
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, theRB.velocity.y);

            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, .2f, whatisGround);

            if (Input.GetButtonDown("Jump") && isGrounded) // && isGrounded
            {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
            }

            //flip direction
            if (theRB.velocity.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (theRB.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1f, 1, 1f);
            }
            
            //handle wall jumping
            canGrab = Physics2D.OverlapCircle(wallGrabPoint.position,.2f, whatisGround);
            isGrabbing = false;
            if(canGrab && !isGrounded)
            {
                if((transform.localScale.x == 1f && Input.GetAxisRaw("Horizontal") > 0)||(transform.localScale.x == -1f && Input.GetAxisRaw("Horizontal") < 0))
                {
                    isGrabbing = true;
                }
            }

            if(isGrabbing){
                theRB.gravityScale = 0f;
                theRB.velocity = Vector2.zero;

                // if(Input.GetButtonDown("Jump")){
                //     if(Input.GetButtonDown("left") || Input.GetButtonDown("right")){
                //         wallJumpCounter = wallJumpTime;
                //         theRB.velocity = new Vector2( -Input.GetAxisRaw("Horizontal") * moveSpeed,jumpForce);
                //         theRB.gravityScale = gravityStore;
                //         isGrabbing = false;
                //     }
                // }

                if(Input.GetButtonDown("Jump")){
                    
                    wallJumpCounter = wallJumpTime;
                    theRB.velocity = new Vector2( -Input.GetAxisRaw("Horizontal") * moveSpeed,jumpForce);
                    if (theRB.velocity.x > 0)
                    {
                        transform.localScale = Vector3.one;
                    }else if (theRB.velocity.x < 0)
                    {
                        transform.localScale = new Vector3(-1f, 1, 1f);
                    }
                    theRB.gravityScale = gravityStore;
                    isGrabbing = false;                    
                }
            }else{
                theRB.gravityScale = gravityStore;
            }
        }
        else{
            wallJumpCounter -= Time.deltaTime;
        }


        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("isGrounded", isGrounded);
        anim.SetBool("isGrabbing", isGrabbing);
    }


    private void OnTriggerStay2D(Collider2D collider)
    {
       isGrounded = collider != null && (((1 << collider.gameObject.layer) & whatisGround) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

}
