using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private Bird bird;

    private bool statusTrigger = false; // berfungsi untuk menandai jikalau player sudah trigger, agar tidak trigger berkali"

    [SerializeField] private AudioSource birdSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (statusTrigger == false)
            {
                birdSound.Play();
                bird.statusBird = true;
                statusTrigger = true;
            }
        }
    }
}
