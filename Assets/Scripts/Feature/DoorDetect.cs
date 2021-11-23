using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDetect : MonoBehaviour
{
    public Text intruksiText;
    public PlayerKeyDetect pm;
    public int status = 0;
    public GameObject textObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (pm.statusKey == true)
            {

                status = 1;
            }
            else
            {
                textObject.SetActive(true);
                intruksiText.text = "Ambil Kunci Terlebih Dahulu";
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            textObject.SetActive(false);
        }
    }


}