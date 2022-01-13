using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlayer : MonoBehaviour
{
    [HideInInspector] public bool statusPlayer;

    [SerializeField] private AudioSource seesawSound;
    private bool seesawSFXon;

    public TriggerBox tb;

    private void Update()
    {
        if(statusPlayer == true && tb.statusBox == true)
        {
            seesawSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            statusPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            statusPlayer = false;
        }
    }
}
