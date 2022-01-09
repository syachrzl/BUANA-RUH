using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding2 : MonoBehaviour
{
    [HideInInspector] public bool statusHideS1 = false;
    [HideInInspector] public bool statusHideF1 = true;
    [HideInInspector] public bool statusTombol1 = false;


    private void Update()
    {
        if (statusTombol1 == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (statusHideS1 == false)
                {
                    statusHideS1 = true;
                    statusHideF1 = false;
                }
                else if (statusHideF1 == false)
                {
                    statusHideS1 = false;
                    statusHideF1 = true;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rumput")
        {
            statusTombol1 = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rumput")
        {
            statusTombol1 = false;
        }
    }
}
