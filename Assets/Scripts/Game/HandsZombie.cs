﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsZombie : MonoBehaviour
{
    //SEDANG DALAM PERBAIKAN CODE
    public GameObject player;
    public Rigidbody2D playerRB;

    public Transform handZombie;
    public Transform target;
    //public Collider2D groundColl;

    public float speed = 0.8f;

    private bool statusHand = false;
    //public PlayerDeath pd;

    private void Start()
    {
        //groundColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (statusHand == true)
        {
            // stop gerakan player
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            // agar player bisa masuk ke dalam tanah
            //groundColl.isTrigger = true;
            // agar gerakan player sama dengan tangan zombie yang akan masuk kedalam tanah
            // player.transform.SetParent(handZombie, true);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position.y <= target.position.y)
        {
            //pd.statusDie = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
            statusHand = true;
        }
    }
}