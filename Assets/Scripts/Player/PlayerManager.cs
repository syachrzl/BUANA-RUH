using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; // Ketika mati maka gameover
    public GameObject startScreen; // Untuk Mengaktifkan Start
    public static Vector2 lastCheckPointPos = new Vector2(-500, 0);



    private void Awake()
    {
        isGameOver = false;
        GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
    }

    void Update()
    {
        if (isGameOver)
        {
            //gameOverScreen.SetActive(true);
            ReplayLevel();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            startScreen.SetActive(true);
        }
    

    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

