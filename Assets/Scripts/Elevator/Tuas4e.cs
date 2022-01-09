using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Tuas4e : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public TextMeshProUGUI instructionText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform4e plat;

    public bool statusPlat = false;

    //Kode Unik
    public bool kodePlat0 = false;

    private void Update()
    {
        if (pt.statusTuasUp == true)
        {
            statusPlat = true;
        }
        else if (pt.statusTuasDown == true)
        {
            statusPlat = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(true);
            instructionText.text = "Press E";
            kodePlat0 = true;
            statusPlat = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(false);
            statusPlat = false;
        }
    }
}
