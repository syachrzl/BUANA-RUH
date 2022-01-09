using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HidingInBush2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instruksi;
    [SerializeField] private GameObject textObject;

    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private Hiding2 hide;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {

        if (hide.statusHideS1 == true)
        {
            sprite.sortingOrder = 2;
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = new Vector2(transform.position.x, transform.position.y);
        }
        else if (hide.statusHideF1 == true)
        {
            playerRb.constraints = RigidbodyConstraints2D.None;
            playerRb.constraints = RigidbodyConstraints2D.FreezeRotation;
            sprite.sortingOrder = -1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            textObject.SetActive(true);
            instruksi.text = "Press E";
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            textObject.SetActive(false);
        }
    }
}
