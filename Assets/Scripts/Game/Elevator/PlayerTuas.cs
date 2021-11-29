using UnityEngine;

public class PlayerTuas : MonoBehaviour
{
    public bool statusTuasUp = false;
    public bool statusTuasDown = true;

    private bool statusTombol = false;

    [SerializeField] private KeyCode tombolTuas = KeyCode.E;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        statusTombol = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        statusTombol = false;
    }
}