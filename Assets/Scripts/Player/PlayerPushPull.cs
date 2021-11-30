﻿using UnityEngine;
using System.Collections;

public class PlayerPushPull : MonoBehaviour
{

    public float distance = 1f;
    public LayerMask boxMask;
    private Animator anim;
    public GameObject box;
    // Use this for initialization 
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame 
    void Update()
    {

        Physics2D.queriesStartInColliders = false;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance, boxMask);

        if (hit.collider != null && hit.collider.gameObject.tag == "Pushable" && Input.GetKeyDown(KeyCode.F))
        {
            // ASSET ADA SPACE DIBAWAH JADI MC MELAYANG
            //anim.SetBool("push", Input.GetKeyDown(KeyCode.F));

            box = hit.collider.gameObject;
            box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
            box.GetComponent<FixedJoint2D>().enabled = true;
            box.GetComponent<BoxPull>().beingPushed = true;

        }
        else if (Input.GetKeyUp(KeyCode.F))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<BoxPull>().beingPushed = false;
        }

    }


    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;

        Gizmos.DrawLine(transform.position, (Vector2)transform.position + Vector2.right * transform.localScale.x * distance);



    }
}