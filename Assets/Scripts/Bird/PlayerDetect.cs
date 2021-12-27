using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour
{
    [SerializeField] private Bird bird;

    private bool statusTrigger = false; // berfungsi untuk menandai jikalau player sudah trigger, agar tidak trigger berkali"

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (statusTrigger == false)
            {
                bird.statusBird = true;
                statusTrigger = true;
            }
        }
    }
}
