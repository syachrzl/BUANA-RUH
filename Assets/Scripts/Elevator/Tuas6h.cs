using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tuas6h : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public TextMeshProUGUI instructionText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform6h plat;

    public bool statusPlat = false;

    //Kode Unik
    public bool kodePlat3 = false;

    //Animasi
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (pt.statusTuasUp == true)
        {
            statusPlat = true;
            anim.SetBool("lever", true);
        }
        else if (pt.statusTuasDown == true)
        {
            statusPlat = false;
            anim.SetBool("lever", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(true);
            instructionText.text = "Press E";
            kodePlat3 = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(false);
            kodePlat3 = false;

        }
    }
}
