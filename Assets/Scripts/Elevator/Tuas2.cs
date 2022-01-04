using UnityEngine;
using UnityEngine.UI;

public class Tuas2 : MonoBehaviour
{
    // untuk tampilan instruksi di layar 
    public Text instruksiText;
    public GameObject instrukObject;

    public PlayerTuas pt;
    public Platform2 plat;

    public bool statusPlat = false;
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
            anim.SetBool("lever",true);
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