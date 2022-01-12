using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActive : MonoBehaviour
{
    public GameObject hantu;
    [SerializeField] private AudioSource screamSound;
    [SerializeField] private AudioSource backsound4;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            screamSound.Play();
            backsound4.Play();
            hantu.SetActive(true);
        }
    }
}
