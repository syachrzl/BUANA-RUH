using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    [HideInInspector] public bool statusBox;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pushable")
        {
            statusBox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Pushable")
        {
            statusBox = false;
        }
    }
}
