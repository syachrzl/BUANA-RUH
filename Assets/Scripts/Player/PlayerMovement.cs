using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //MOVEMENT
    [Header("MOVEMENT")]
    [SerializeField] private float walkspeed;
    [SerializeField] private float Runspeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float upSpeed;
    private float wallJumpCooldown;
    public float horizontalInput;
    private float speed;

    //LAYER
    [Header("LAYER")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    //REFERENCE
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    [Header("PUSHPULL")]
    //PUSH PULL
    public bool StatusPushPull = false;
    public float distance;
    public LayerMask boxMask;
    public GameObject box;

    //PLAYER RUN OR WALK
    [Header("RUN STATUS, LADDER AND SLIDE")]
    [Range(0.01f, 1.5f)] public float timeDuration = 1f;
    private float clickTimeRight, clickTimeLeft;
    private float timeLastRight, timeLastLeft;
    [HideInInspector] public bool statusRun;
    [HideInInspector] public bool statusWalk = true;


    //LADDER MOVEMENT
    private float vert;
    private bool isLadder = false;
    public bool isClimbing = false;

    //SLIDE
    [HideInInspector] bool slider = false;
    [HideInInspector] public bool statusTraps = false;
    [SerializeField] private float slideSpeed;

    //BIRD
    public Bird bird;

    private void Awake()
    {
        // Mengambil referensi untuk rigidbody dan animator dari objek  
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        //Pergerakan MC
        RunOrWalk();
        Kanan();
        Kiri();

        //Memeriksa input horizontal untuk mementukan animasi bergerak kekiri dan kekanan
        horizontalInput = Input.GetAxis("Horizontal");

        //Slide / Meluncur
        if (slider == true)
        {
            body.velocity = new Vector2(slideSpeed += Time.deltaTime * 50, body.velocity.y);
        }
        //Bird / Melambat
        else if (bird.slowdown == true)
        {
            body.velocity = new Vector2(horizontalInput * speed / 2 , body.velocity.y);
        } 
        else
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }

       
        PushPull();
        JumpOnWall();

        anim.SetBool("walk", horizontalInput!=0);
        anim.SetBool("grounded", isGrounded());

    }

    private void FixedUpdate()
    {
        vert = Input.GetAxisRaw("Vertical");

        //MENENTUKAN ANIMASI SAAT MENAIKI TANGGA
        if (isClimbing == true && vert == 1 || isClimbing == true && vert == -1)
        {
            anim.SetBool("uphill", true);
            anim.SetBool("idleUphill", false);
        } else if (isClimbing == true && vert == 0)
        {
            anim.SetBool("uphill", false);
            anim.SetBool("idleUphill", true);
        } else
        {
            anim.SetBool("uphill", false);
            anim.SetBool("idleUphill", false);
        }

        if (isLadder && Mathf.Abs(vert) > 0f)
        {
            isClimbing = true;
        }

            if (isClimbing)
            {
                body.gravityScale = 0f;
                body.velocity = new Vector2(body.velocity.x, vert * upSpeed);
            }


        

    }

    private void RunOrWalk()
    {
        //Menentukan apakah dia lari atau berjalan
        if (statusRun == true && statusWalk == false)
        {
            speed = Runspeed;
        }
        else if (statusRun == false && statusWalk == true)
        {
            speed = walkspeed;
        }


        //Jika berlari maka animasi berubah 
        if (horizontalInput > 0.01f)
        {
            if (statusRun == true)
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("walk", true);
                transform.localScale = new Vector3(1, 1, 1);
            }
        }

        else if (horizontalInput < -0.01f)
        {

            if (statusRun == true)
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }

    //Menentukan input horizontal, jika double click maka MC berlari
    void Kanan()
    {
        if (Input.GetKeyDown(KeyCode.D)  || Input.GetKeyDown(KeyCode.RightArrow) )
        {
            timeLastRight = Time.time - clickTimeRight;
            if (timeLastRight <= timeDuration)
            {
                statusRun = true;
                statusWalk = false;
            }
            else
            {
                statusWalk = true;
                statusRun = false;
            }
            clickTimeRight = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow ) )
        {
            statusRun = false;
            statusWalk = true;
        }
    }

    void Kiri()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) )
        {
            timeLastLeft = Time.time - clickTimeLeft;
            if (timeLastLeft <= timeDuration)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                statusRun = true;
                statusWalk = false;
            }
            else
            {
                statusWalk = true;
                statusRun = false;
            }
            clickTimeLeft = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.A)|| Input.GetKeyUp(KeyCode.LeftArrow))
        {
            statusRun = false;
            statusWalk = true;
        }
    }


    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");

            anim.SetBool("idleUphill", false);
        anim.SetBool("uphill", false);
        }    
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;

        
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    //Agar tidak bisa lompat ke dinding
    private void JumpOnWall()
    { 
        if (wallJumpCooldown < 0.2f)
        {
            if (onWall() && !isGrounded())
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 0, 0);
                body.gravityScale = 50;
                //transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.y);
            }
            else
                body.gravityScale = 7;

            if (Input.GetKey(KeyCode.Space))
                Jump();
        }
        else
            wallJumpCooldown += Time.deltaTime;
    }

    //Function untuk Push dan Pull Box
    public void PushPull()
    {
        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.F) && isGrounded())
        {
            StatusPushPull = true;
            
            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;
        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
            //transform.localScale = new Vector3(1, 1, 1);
            StatusPushPull = false;
        }

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
            isClimbing = true;
        }

        if (collision.CompareTag("Slide"))
        {
            slider = true;
        }

        if (collision.CompareTag("Traps"))
        {
            statusTraps = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            anim.SetBool("uphill", false);
            anim.SetBool("idleUphill", false);
        }

        if (collision.CompareTag("Slide"))
        {
            slider = false;
        }

        if (collision.CompareTag("Traps"))
        {
            statusTraps = false;
        }
    }


}
