using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOff : MonoBehaviour
{
    public GameObject stone;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Stone")
        {
            stone.tag = "Ground";
        }
    }

   
}
