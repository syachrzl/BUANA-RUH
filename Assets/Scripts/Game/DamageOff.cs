using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOff : MonoBehaviour
{
    [SerializeField] private AudioSource stoneSound;
    private bool stoneSFXon;

    public GameObject stone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Stone")
        {
            stone.tag = "Ground";
            stoneSFXon = true;

            if (stoneSFXon == true && stoneSound.isPlaying == false)
            {
                stoneSound.Play();
            }
            else if (stoneSFXon == false && stoneSound.isPlaying == true)
            {
                stoneSound.Stop();
            }
        }
    }

   
}
