using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tuas : MonoBehaviour
{
    public Text instruksiText;
    public GameObject ins;
    public PlayerMovement pm;
    public MovingPlatform plat;
    public bool statusPlat = false;

    private void Update()
    {
        if (pm.statusTuasUp == true)
        {
            statusPlat = true;
        }
        else if (pm.statusTuasDown == true)
        {
            statusPlat = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ins.SetActive(true);
            instruksiText.text = "Press Q";
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            ins.SetActive(false);
        }
    }

}