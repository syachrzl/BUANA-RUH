using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class HidingInBush : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI instruksi;
    [SerializeField] private GameObject textObject;

    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D playerRb;

    [SerializeField] private Hiding hide;

    private SpriteRenderer sprite;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        if (hide.statusHideS == true)
        {
            sprite.sortingOrder = 2;
            playerRb.constraints = RigidbodyConstraints2D.FreezeAll;
            player.transform.position = new Vector2(transform.position.x, player.transform.position.y);
        }
        else if (hide.statusHideF == true)
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
            instruksi.text = "Press E to Hide";
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
