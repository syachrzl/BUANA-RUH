using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;
using TMPro;

public class Tuas : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public TextMeshProUGUI instructionText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform plat;

    public bool statusPlat = false;

    //Kode Unik
    public bool kodePlat1 = false;
   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(true);
            instructionText.text = "Press E";
            kodePlat1 = true;
            statusPlat = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(false);
            kodePlat1 = false;
            statusPlat = false;
        }
    }
}