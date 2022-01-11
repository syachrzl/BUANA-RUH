using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerStone : MonoBehaviour
{
    public Rigidbody2D rbStone;
    [SerializeField] private AudioSource stoneSound;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            stoneSound.Play();
            rbStone.bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
