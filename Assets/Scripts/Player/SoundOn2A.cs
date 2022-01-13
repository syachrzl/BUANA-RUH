using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn2A : MonoBehaviour
{
    [SerializeField] private AudioSource fallSound;
    private bool fallSFXon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Stone")
        {
            fallSFXon = true;

            if (fallSFXon == true && fallSound.isPlaying == false)
            {
                fallSound.Play();
            }
            else if (fallSFXon == false && fallSound.isPlaying == true)
            {
                fallSound.Stop();
            }
        }
    }
}
