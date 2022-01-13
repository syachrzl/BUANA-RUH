using UnityEngine;

public class PlayerTuas : MonoBehaviour
{
    public bool statusTuasUp = false;
    public bool statusTuasDown = true;

    private bool statusTombol = false;

    [SerializeField] private KeyCode tombolTuas = KeyCode.E;
    [SerializeField] private AudioSource tuasSound;
    private bool tuasSFXon = false;

    private void Update()
    {
        if (statusTombol == true)
        {
            if (Input.GetKeyDown(tombolTuas))
            {
                if (statusTuasUp == true)
                {
                    statusTuasUp = false;
                    statusTuasDown = true;
                }
                else if (statusTuasDown == true)
                {
                    statusTuasUp = true;
                    statusTuasDown = false;
                }
            }
        }

        if (tuasSFXon == true && Input.GetKey(KeyCode.E))
        {
            tuasSound.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tuas")
        {
            statusTombol = true;
            tuasSFXon = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Tuas")
        {
            statusTombol = false;
            tuasSFXon = false;
        }
    }
}