using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private float timer = 1.4f;
    private bool setTimer = false;
    private bool setriger = false;

    [SerializeField] private AudioSource dieSound;
    

    private void Update()
    {
        if (setTimer == true)
        {
            timer -= Time.deltaTime;

            if(timer < 1f)
            {
                setriger = true;
            }
        }

        if (setriger == true)
        {
            PlayerManager.isGameOver = true;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Obstacle")
        {
            dieSound.Play();
            setTimer = true;
        }
    }

   
}
