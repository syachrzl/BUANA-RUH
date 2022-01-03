using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //Bird
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform pointWayPalingKiri;
    [SerializeField] private Transform pointWayPalingKanan;
    [SerializeField] private Hiding hide;

    [HideInInspector] public bool statusBird = false;

    public bool statusBirRun = false;
    public bool slowdown;

    private void Awake()
    {
        slowdown = false;
    }

    private void Update()
    {
        // kendali pergerakan dengan script waypointfollower
        if (this.GetComponent<WayPointFollower>().enabled == true)
        {
            if (Vector2.Distance(pointWayPalingKiri.position, transform.position) < .1f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (Vector2.Distance(pointWayPalingKanan.position, transform.position) < .1f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }

        if (statusBird == true)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            this.GetComponent<WayPointFollower>().enabled = false;
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (player.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            if (hide.statusHideS == true)
            {
                statusBird = false;
                statusBirRun = true;
            }
        }

        if (statusBirRun == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, Vector2.up * 5000, (speed + 5f) * Time.deltaTime);
            Invoke("SelfDestruct", 10f);
        }

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log(slowdown);
            SelfDestruct();
        }
    }

    void SelfDestruct()
    {
        slowdown = true;
        Destroy(gameObject);
    }

  

}
