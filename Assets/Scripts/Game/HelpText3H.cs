using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HelpText3H : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public TextMeshProUGUI instructionText;
    public GameObject instrukObject;

    public float timer;
    private bool setTimer = false;
    private bool setriger = false;

    private void Update()
    {
        if (setTimer == true)
        {
            timer += Time.deltaTime;

            if (timer > 4f && timer <= 6f)
            {
                setriger = true;
            } else
            {
                setriger = false;
            }
        }

        if (setriger == true)
        {
            instrukObject.SetActive(true);
            instructionText.text = "Take the box on the tree!";
        } else
        {
            instrukObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            setTimer = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            setriger = false;
        }
    }
}
