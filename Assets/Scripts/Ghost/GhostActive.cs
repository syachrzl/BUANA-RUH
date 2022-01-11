using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostActive : MonoBehaviour
{
    public GameObject hantu;
    [SerializeField] private AudioSource screamSound;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            screamSound.Play();
            hantu.SetActive(true);
        }
    }
}
