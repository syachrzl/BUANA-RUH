using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //MOVEMENT
    [Header("MOVEMENT")]
    [HideInInspector] private float walkspeed = 20;
    [HideInInspector] private float Runspeed = 30;
    [HideInInspector] private float jumpPower = 50;
    [HideInInspector] private float upSpeed = 25;
    private float wallJumpCooldown;
    [HideInInspector] public float horizontalInput;
    private float speed;

    //LAYER
    [Header("LAYER JUMP")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    //REFERENCE
    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    [Header("PUSHPULL")]
    //PUSH PULL
    [HideInInspector] public bool StatusPushPull = false;
    [HideInInspector] public float distance;
    [HideInInspector] public LayerMask boxMask;
    [HideInInspector] public GameObject box;

    //PLAYER RUN OR WALK
    [Header("RUN TIME DURATION, BIRD")]
    [Range(0.01f, 1.5f)] public float timeDuration = 1f;
    private float clickTimeRight, clickTimeLeft;
    private float timeLastRight, timeLastLeft;
    [HideInInspector] public bool statusRun;
    [HideInInspector] public bool statusWalk = true;


    //LADDER MOVEMENT
    private float vert;
    [HideInInspector] private bool isLadder = false;
    [HideInInspector] public bool isClimbing = false;

    //SLIDE
    [HideInInspector] bool slider = false;
    [HideInInspector] public bool statusTraps = false;
    [HideInInspector] private float slideSpeed = 27;

    //BIRD
    public Bird bird;
    public Bird2 bird2;

    //SOUND EFFECT
    [Header("SOUND EFFECT")]
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource walkSound;
    private bool walkSFXon;
    [SerializeField] private AudioSource runSound;
    private bool runSFXon;
    [SerializeField] private AudioSource pushpullSound;
    private bool pushpullSFXon;
    [SerializeField] private AudioSource climbingSound;
    private bool climbingSFXon;

    private void Awake()
    {
        // Mengambil referensi untuk rigidbody dan animator dari objek  
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        //Animasi pushpull
        PushPullAnimation();

        //Memeriksa input horizontal untuk mementukan animasi bergerak kekiri dan kekanan
        horizontalInput = Input.GetAxis("Horizontal");

        //Slide saat diturunan tajam
        isSlider();

        //Pergerakan MC
        RunOrWalk();
        Kanan();
        Kiri();
        PushPull();
        JumpOnWall();
        onPushPull();

        //Animasi
        anim.SetBool("walk", horizontalInput != 0 && StatusPushPull == false);
        anim.SetBool("grounded", isGrounded());
    }

    private void FixedUpdate()
    {
        onLadder();
    }

    private void RunOrWalk()
    {
        //Menentukan apakah dia lari atau berjalan
        if (statusRun == true && statusWalk == false)
        {
            speed = Runspeed;
            walkSound.Stop();

            runSFXon = true;

            if (runSFXon == true && runSound.isPlaying == false)
            {
                runSound.Play();
            }
            else if (runSFXon == false && runSound.isPlaying == true)
            {
                runSound.Stop();
            }
            else if (!isGrounded())
            {
                runSound.Stop();
            }
        }
        else if (statusRun == false && statusWalk == true)
        {
            speed = walkspeed;
            walkSFXon = true;

            runSound.Stop();

            if (walkSFXon == true && walkSound.isPlaying == false)
            {
                walkSound.Play();
            }
            else if (walkSFXon == false && walkSound.isPlaying == true)
            {
                walkSound.Stop();
            } else if (!isGrounded())
            {
                walkSound.Stop();
            }
        } 

        //Jika berlari maka animasi berubah 
        if (horizontalInput > 0.01f)
        {
            if (statusRun == true)
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("walk", true);
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
        }

        else if (horizontalInput < -0.01f)
        {

            if (statusRun == true)
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
        }  else if (horizontalInput == 0)
        {
            walkSound.Stop();
        }


    }

    //Menentukan input horizontal, jika double click maka MC berlari
    void Kanan()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            timeLastRight = Time.time - clickTimeRight;
            if (timeLastRight <= timeDuration)
            {
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
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
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            statusRun = false;
            statusWalk = true;
        }
    }

    void Kiri()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timeLastLeft = Time.time - clickTimeLeft;
            if (timeLastLeft <= timeDuration)
            {
                if (StatusPushPull == false)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
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
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            statusRun = false;
            statusWalk = true;
        }
    }


    private void Jump()
    {

        if (isGrounded() && StatusPushPull == false || isClimbing == true)
        {
            jumpSound.Play();
            if (Input.GetKey(KeyCode.Space) && isClimbing == true)
            {
                isClimbing = false;
                isLadder = false;
            }
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
            else { 
                body.gravityScale = 7;
            }
            if (Input.GetKey(KeyCode.Space)) { 
                Jump();
            }
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
            StatusPushPull = false;
            anim.SetBool("push", false);
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }

    }

    public void PushPullAnimation()
    {
        //ANIMASI PUSHPULL
        if (horizontalInput == 0 && StatusPushPull == true)
        {
            anim.SetBool("walk", false);
            anim.SetBool("push", false);
            anim.SetBool("idlePull", true);
        }
        else if (horizontalInput != 0 && StatusPushPull == true)
        {
            anim.SetBool("walk", false);
            anim.SetBool("push", true);
            anim.SetBool("idlePull", false);
        }
        else
        {
            anim.SetBool("push", false);
            anim.SetBool("idlePull", false);
        };
    }

    public void onPushPull()
    {
        if(horizontalInput != 0 && StatusPushPull == true)
        {
            pushpullSFXon = true;

            if (pushpullSFXon == true && pushpullSound.isPlaying == false)
            {
                pushpullSound.Play();
            }
            else if (pushpullSFXon == false && pushpullSound.isPlaying == true)
            {
                pushpullSound.Pause();
            }

        } else if (horizontalInput == 0 && StatusPushPull == true)
        {
            pushpullSound.Pause();
        }
        else if (horizontalInput == 0 && StatusPushPull == false)
        {
            pushpullSound.Stop();
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);
    }

    public void isSlider()
    {
        //Slide / Meluncur
        if (slider == true)
        {
            body.velocity = new Vector2(slideSpeed += Time.deltaTime * 50, body.velocity.y);
        }
        //Bird / Melambat
        else if (bird.slowdown == true || bird2.slowdown2 == true)
        {
            body.velocity = new Vector2(horizontalInput * speed / 2, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
        }
    }

    public void onLadder()
    {
        vert = Input.GetAxisRaw("Vertical");

        //MENENTUKAN ANIMASI SAAT MENAIKI TANGGA
        if (isClimbing == true && vert == 1 || isClimbing == true && vert == -1)
        {
            climbingSFXon = true;

            if (climbingSFXon == true && climbingSound.isPlaying == false)
            {
                climbingSound.Play();
            }
            else if (climbingSFXon == false && climbingSound.isPlaying == true)
            {
                climbingSound.Pause();
            }

            anim.SetBool("uphill", true);
            anim.SetBool("idleUphill", false);
        }
        else if (isClimbing == true && vert == 0)
        {
            climbingSound.Stop();
            anim.SetBool("uphill", false);
            anim.SetBool("idleUphill", true);
        }
        else
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            if (StatusPushPull == true)
            {
                isLadder = false;
                isClimbing = false;
            }
            else
            {
                isLadder = true;
                isClimbing = true;
            }

         
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

            climbingSound.Stop();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            anim.SetTrigger("die");
        }
    }


}
