using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn3G : MonoBehaviour
{
    [SerializeField] private AudioSource boxSound;
    private bool boxSFXon;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Box")
        {
            boxSFXon = true;

            //BACKSOUND ON
            if (boxSFXon == true && boxSound.isPlaying == false)
            {
                boxSound.Play();
            }
            else if (boxSFXon == false && boxSound.isPlaying == true)
            {
                boxSound.Stop();

            }
        }
    }
}
