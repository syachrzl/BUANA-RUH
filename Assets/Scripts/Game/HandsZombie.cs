using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsZombie : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D playerRB;

    public Transform handZombie;
    public Transform target;
    public Collider2D groundColl;

    public float speed = 0.8f;

    private bool statusHand = false;

    //SFX
    [SerializeField] private AudioSource screamSound;
    private bool screamSFXon;

    private void Start()
    {
        groundColl = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (statusHand == true)
        {
            // stop gerakan player
            playerRB.constraints = RigidbodyConstraints2D.FreezeAll;
            // agar player bisa masuk ke dalam tanah
            groundColl.isTrigger = true;
            // agar gerakan player sama dengan tangan zombie yang akan masuk kedalam tanah
            player.transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }

        if (transform.position.y <= target.position.y)
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
            statusHand = true;

            screamSFXon = true;

            if (screamSFXon == true && screamSound.isPlaying == false)
            {
                screamSound.Play();
            }
            else if (screamSFXon == false && screamSound.isPlaying == true)
            {
                screamSound.Stop();
            }
        }
    }
}
