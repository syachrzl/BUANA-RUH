using UnityEngine;
using UnityEngine.UI;

public class Tuas : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public Text instruksiText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform plat;

    public bool statusPlat = false;

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