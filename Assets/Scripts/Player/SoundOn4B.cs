using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn4B : MonoBehaviour
{
    [SerializeField] private AudioSource woodSound;
    private bool woodSFXon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            woodSFXon = true;

            //BACKSOUND ON
            if (woodSFXon == true && woodSound.isPlaying == false)
            {
                woodSound.Play();
            }
            else if (woodSFXon == false && woodSound.isPlaying == true)
            {
                woodSound.Stop();
            }
        }
    }
}
