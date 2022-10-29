using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    Animator anim;
    AudioSource Music;
    Collider2D coll;
    Gameover gameover;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckPoint;
    [SerializeField] LayerMask groundlayer;
    [SerializeField] Transform wallCheckPoint;
    [SerializeField] LayerMask walllayer;
    [SerializeField] LayerMask ground;
    [SerializeField] LayerMask wall;

    private float horizontalValue;
    public float moveSpeed, JumpForce, slidefactor;
    private bool facingRigth = true;
    public int totalJump;
    public int avaliablejump;
    const float groundCheckRadius = 0.2f;
    const float wallCheckRadius = 0.2f;
    private bool jumpdelay;
    private bool multiplejump;
    private bool isGrabing;
    private bool IsMoving = false;
    private int poin;
   
    
    // Start is called before the first frame update
    private void Awake()
    {
        avaliablejump = totalJump;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        Music = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        horizontalValue = Input.GetAxisRaw("Horizontal");
        lompat();
        wallCheck();
    }

    void FixedUpdate()
    {
        Movement(horizontalValue);
        GroundCheck();
    }

    void Movement(float dir)
    {

        //vector2 buat rb
        rb.velocity = new Vector2(dir * moveSpeed, rb.velocity.y);
        if (dir != 0){
            IsMoving = true;
        } 
        else
        {
            IsMoving = false;
        }

        if (IsMoving && coll.IsTouchingLayers(ground))
        {
            if(!Music.isPlaying)
            Music.Play();
        }
        else
        {
            Music.Stop();
        }

        //flip kiri 
        if (facingRigth && dir < 0)
        {
            Flip();
        }

        //flip kanan
        if (!facingRigth && dir > 0)
        {
            Flip();       
        }


        //mengatur nilai xspeed berdasar nilai x rb
        anim.SetFloat("xspeed", Mathf.Abs(rb.velocity.x));
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false; 
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, groundCheckRadius, groundlayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                avaliablejump = totalJump;
                multiplejump = false;

                Audio.instance.PlaySFX("landing");
                
            }
        }
        else
        {
            if (wasGrounded)
                StartCoroutine(JumpDelay());
        }

        if (coll.IsTouchingLayers(wall))
        {
            anim.SetBool("grab", true);
        }

        // jika tidak di ground animasi lompat = true;
        if (!coll.IsTouchingLayers(wall))
        {
            anim.SetBool("grab", false);
        }

    }

    void wallCheck()
    {
        if(Physics2D.OverlapCircle(wallCheckPoint.position, wallCheckRadius, walllayer)
            && Mathf.Abs(horizontalValue) > 0 && rb.velocity.y < 0 && !isGrounded)
        {
            if (!isGrabing)
            {
                avaliablejump = totalJump;
                multiplejump = false;
            }
            Vector2 v = rb.velocity;
            v.y = -slidefactor;
            rb.velocity = v;
            isGrabing = true;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                avaliablejump--;
                //perpindahan vector 2 y.
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
            }
        }
        else
        {
            isGrabing = false;
        }
    }

    private void Flip()
    {
        // mengganti arah player melihat.
        facingRigth = !facingRigth;
        transform.Rotate(0f, 180f, 0f);
    }

    private void lompat()
    {
        //tekan spasi dan menyentuh layer ground = lompat
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            if (isGrounded)
            {
                multiplejump = true;
                avaliablejump--;
                //perpindahan vector 2 y.
                rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                Audio.instance.PlaySFX("jump");
            }

            //menjalankan fungsi jumpdelay
            else
            {
                if (jumpdelay)
                {
                    multiplejump = true;
                    avaliablejump--;
                    //perpindahan vector 2 y.
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                    Audio.instance.PlaySFX("jump");
                }

                if (multiplejump && avaliablejump >0)
                {
                    avaliablejump--;
                    //perpindahan vector 2 y.
                    rb.velocity = new Vector2(rb.velocity.x, JumpForce);
                    Audio.instance.PlaySFX("jump");
                }
                
            }
        }

        // jika masih di ground animasi lompat = false
        if (coll.IsTouchingLayers(ground) || coll.IsTouchingLayers(wall))
        {
            anim.SetBool("jump", false);
        }

        // jika tidak di ground animasi lompat = true;
        if (!coll.IsTouchingLayers(ground) && !coll.IsTouchingLayers(wall))
        {
            anim.SetBool("jump", true);
        }

        //mengatur nilai xspeed berdasar nilai y rb
        anim.SetFloat("yspeed", rb.velocity.y);

    }

    IEnumerator JumpDelay()
    {
        // waktu sebelum ground hilang
        jumpdelay = true;
        yield return new WaitForSeconds(0.6f);
        jumpdelay = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "item")
        {
            // jika menyentuh maka object akan hancur dan gem bertambah 1
            Destroy(collision.gameObject);
            Audio.instance.PlaySFX("item");
            poin += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D player)
    {
        if (player.gameObject.CompareTag("Trap"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            GameOver();
        }


    }

    private void GameOver()
    {
        gameover.Setup(poin);
    }

}
