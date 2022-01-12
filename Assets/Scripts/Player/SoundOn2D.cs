using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOn2D : MonoBehaviour
{
    [SerializeField] private AudioSource backsound3;
    private bool backsound3On;

    private void Update()
    {
        //BACKSOUND ON
        if (backsound3On == true && backsound3.isPlaying == false)
        {
            backsound3.Play();
        }
        else if (backsound3On == false && backsound3.isPlaying == true)
        {
            backsound3.Stop();

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            backsound3On = true;
        }
    }
}
