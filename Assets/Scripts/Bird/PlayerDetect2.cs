using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect2 : MonoBehaviour
{
    [SerializeField] private Bird2 bird;
    [SerializeField] private Bird2 bird2;
    [SerializeField] private Bird2 bird3;
    [SerializeField] private Bird2 bird4;
    [SerializeField] private Bird2 bird5;

    private bool statusTrigger = false; // berfungsi untuk menandai jikalau player sudah trigger, agar tidak trigger berkali"

    [SerializeField] private AudioSource birdSound;
    private bool birdSFXon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (statusTrigger == false)
            {
                birdSound.Play();
                bird.statusBird = true;
                bird2.statusBird = true;
                bird3.statusBird = true;
                bird4.statusBird = true;
                bird5.statusBird = true;
                statusTrigger = true;
            }
        }
    }
}
