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
        
        //Run or Walk
        if (horizontalInput > 0.01f) { 
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                transform.localScale = new Vector3(1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed , body.velocity.y);
            } else
            {
                anim.SetBool("run", false);
                anim.SetBool("walk", true);
                transform.localScale = new Vector3(1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
            }
        }
        else if (horizontalInput < -0.01f) {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("run", true);
                transform.localScale = new Vector3(-1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * Runspeed, body.velocity.y);
            }
            else
            {
                anim.SetBool("walk", true);
                anim.SetBool("run", false);
                transform.localScale = new Vector3(-1, 1, 1);
                body.velocity = new Vector2(Input.GetAxis("Horizontal") * walkspeed, body.velocity.y);
            }
        }


      
        anim.SetBool("grounded", isGrounded());

        //Jump to Wall
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

    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpPower);
            anim.SetTrigger("jump");
        }
        else if(onWall() && !isGrounded())
        {
            body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 0, 0);
            //transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.y);
            
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
}
