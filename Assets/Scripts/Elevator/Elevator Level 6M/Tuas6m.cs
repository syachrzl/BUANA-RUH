using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tuas6m : MonoBehaviour
{
    // untuk tampilan instruksi di layar
    public TextMeshProUGUI instruksiText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform6m plat;

    [HideInInspector] public bool statusPlat = false;

    //Animasi
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
       

        if (pt.statusTuasUp == true)
        {
            statusPlat = true;
            anim.SetBool("lever", true);
            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (pt.statusTuasDown == true)
        {
            statusPlat = false;
            anim.SetBool("lever", false);
            //transform.rotation = Quaternion.Euler(0, 0, -0);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(true);
            instruksiText.text = "Press E";
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            instrukObject.SetActive(false);
        }
    }
}
