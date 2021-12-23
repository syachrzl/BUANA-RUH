using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; // Ketika mati maka gameover
    public GameObject startScreen; // Untuk Mengaktifkan Start
    public static Vector3 lastCheckPointPos = new Vector3(-500, 0, 0);
    public static float puzzleTotal;
    public float TotalPuzzle;

    private void Awake()
    {
        isGameOver = false;
        //GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
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

        TotalPuzzle = puzzleTotal;

        //DEBUGING
        SavePlayer();
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        UserProgressData data = SaveSystem.LoadPlayer();

        PuzzleCollectible.alreadyTaken = data.AlreadyTaken;
        puzzleTotal = data.TotalPuzzle;

        //PuzzleCollectible.catchId = data.IdPuzzle;


        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        lastCheckPointPos = transform.position;
    }

    public void NewGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        LoadPlayer();
        SceneManager.LoadScene(1);

    }

    public void QuitGame()
    {
  
        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void ExitGame()
    {

        SceneManager.LoadScene(0);
    }
}

