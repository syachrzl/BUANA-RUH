using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Menentukan Speed
    [SerializeField] private float speed;
    //Speed untuk lompat
    [SerializeField] private float jump;
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Untuk bisa berjalan ke kiri dan ke kanan
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // Agar dapat melompat dengan mempertahankan kecepatan horizontal
        if (Input.GetKey(KeyCode.Space))
            body.velocity = new Vector2(body.velocity.x, jump);
    }
}
