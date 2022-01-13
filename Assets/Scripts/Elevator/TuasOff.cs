using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TuasOff : MonoBehaviour
{
    public PlayerTuas pt;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            pt.statusTuasDown = true;
            pt.statusTuasUp = false;
        }
    }
}
