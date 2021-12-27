using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    [HideInInspector] public bool statusHideS = false;
    [HideInInspector] public bool statusHideF = true;
    [HideInInspector] public bool statusTombol = false;


    private void Update()
    {
        if (statusTombol == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (statusHideS == false)
                {
                    statusHideS = true;
                    statusHideF = false;
                }
                else if (statusHideF == false)
                {
                    statusHideS = false;
                    statusHideF = true;
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bush")
        {
            statusTombol = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Bush")
        {
            statusTombol = false;
        }
    }
}
