using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn3C : MonoBehaviour
{

    [SerializeField] private AudioSource zombieSound;
    private bool zombieSFXon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            zombieSFXon = true;

            //BACKSOUND ON
            if (zombieSFXon == true && zombieSound.isPlaying == false)
            {
                zombieSound.Play();
            }
            else if (zombieSFXon == false && zombieSound.isPlaying == true)
            {
                zombieSound.Stop();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        zombieSound.Stop();
    }
}
