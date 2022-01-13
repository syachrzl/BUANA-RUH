using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform4e : MonoBehaviour
{
    public Tuas4e tuas;
    // untuk arah gerakan 
    public GameObject wayPoint1;
    public GameObject wayPoint2;

    [SerializeField] private AudioSource elevatorSound;
    private bool elevatorSFXon;
    private bool elevatorSFXon2 = false;

    public float speed = 2f;
    void Update()
    {
        //SFX ON
        if (Input.GetKey(KeyCode.E) && elevatorSFXon2 == true)
        {
            elevatorSFXon = true;

            if (elevatorSFXon == true && elevatorSound.isPlaying == false)
            {
                elevatorSound.Play();
            }
            else if (elevatorSFXon == false && elevatorSound.isPlaying == true)
            {
                elevatorSound.Stop();
            }
        }

        //SFX STOP
        if (transform.position.x > 4083)
        {
            elevatorSound.Stop();
        }

        //PLATFORM ON
        if (tuas.statusPlat == true && tuas.kodePlat0 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (tuas.statusPlat == false && tuas.kodePlat0 == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }


    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            elevatorSFXon2 = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            elevatorSFXon2 = false;
        }
    }
}
