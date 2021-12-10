using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkspeed;
    [SerializeField] private float Runspeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float wallJumpCooldown;
    private float horizontalInput;

    //PUSH PULL
    public bool StatusPushPull = false;
    public float distance;
    public LayerMask boxMask;
    public GameObject box;

    private void Awake()
    {
        // Mengambil referensi untuk rigidbody dan animator dari objek  
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }


    private void Update()
    {
        //Memeriksa input horizontal untuk mementukan animasi bergerak kekiri dan kekanan
        horizontalInput = Input.GetAxis("Horizontal");

        PushPull();
        JumpOnWall();
        RunOrWalk();


        anim.SetBool("walk", horizontalInput!=0);
        anim.SetBool("grounded", isGrounded());
    }

    private void RunOrWalk()
    {
        if (horizontalInput > 0.01f)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                anim.SetBool("walk", false);
                //anim.SetBool("pullstate", false);
                transform.localScale = new Vector3(1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed, body.velocity.y);
            }
            else
            {
                anim.SetBool("run", false);
                anim.SetBool("walk", true);
               //anim.SetBool("pullstate", false);
                transform.localScale = new Vector3(1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
            }
        }

        else if (horizontalInput < -0.01f)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", true);
                //anim.SetBool("pullstate", false);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed, body.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
                //anim.SetBool("pullstate", false);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        } else
        {
            anim.SetBool("run", false);
            anim.SetBool("walk", false);
            isGrounded();
        }

        //Mencegah flip saat menarik MASIH NGEBUGGGGGGGGGGGGG
        //else if (horizontalInput < -0.01f && Input.GetKey(KeyCode.F) && StatusPushPull == true)
        //{
        // Debug.Log("SEBELAH KIRI");

        // if (Input.GetKey(KeyCode.LeftShift))
        //   {
        //      anim.SetBool("run", false);
        //      anim.SetBool("pullstate", true);
        //      body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
        //     transform.localScale = new Vector3(1, 1, 1);
        // }
        // else
        // {
        //     anim.SetBool("run", false);
        //      anim.SetBool("pullstate", true);
        //      body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
        //      transform.localScale = new Vector3(1, 1, 1);
        //  }
        //  }
    }


    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
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

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.F))
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
}
