using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            //collision.GetComponent<Health>().TakeDamage(damage);
            PlayerManager.isGameOver = true;
            //jika diperlukan
            gameObject.SetActive(false);
        }
    }

   
}
