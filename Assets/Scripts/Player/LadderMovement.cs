using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float vert;
    [SerializeField] private float speed = 5f;
    private bool isLadder = false;
    public bool isClimbing = false;
    private Animator anim;
    [SerializeField] private Rigidbody2D playerRb;

    void Update()
    {
        vert = Input.GetAxisRaw("Vertical");
        if (isLadder && Mathf.Abs(vert) > 0f)
        {
            isClimbing = true;
        }
    }
    private void FixedUpdate()
    {
        if (isClimbing)
        {
            anim.SetBool("uphill", true);
            playerRb.gravityScale = 0f;
            playerRb.velocity = new Vector2(playerRb.velocity.x, vert * speed);
        }
        else
        {
            anim.SetBool("uphill", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
