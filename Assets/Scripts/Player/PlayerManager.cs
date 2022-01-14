using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver; // Ketika mati maka gameover
    public GameObject startScreen; // Untuk Mengaktifkan Start

    public static Vector3 lastCheckPointPos = new Vector3(-500, 0, 0);

    public static float puzzleTotal;
    public float TotalPuzzle;

    public ControlPanel cp;

    //BACKSOUND
    [SerializeField] private AudioSource backsound1;
    private bool backsound1On;
    [SerializeField] private AudioSource backsound2;
    private bool backsound2On;
    [SerializeField] private AudioSource backsound3;
    private bool backsound3On;
    [SerializeField] private AudioSource backsound4;
    private bool backsound4On;

    //SFX
    [SerializeField] private AudioSource respawnSound;

    private void Awake()
    {
        isGameOver = false;
        if(StatusNewGame.statnewgame == true)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-500, 0, 0);
        } else if(StatusNewGame.statnewgame == false)
        {
            GameObject.FindGameObjectWithTag("Player").transform.position = lastCheckPointPos;
        }  
    }

    void Update()
    {
        if (isGameOver)
        {
            //gameOverScreen.SetActive(true);
            ReplayLevel();
        }

        if (Input.GetKey(KeyCode.Escape) && cp.ControlMenu == false)
        {
            startScreen.SetActive(true);
        }

        TotalPuzzle = puzzleTotal;

        SavePlayer();

        //BACKSOUND
        playBacksound();
    }

    public void ControlStatus()
    {
        cp.ControlMenu = false;
    }

    //HOLD DULU
    public void playBacksound()
    {
  
        if (backsound1On == true && backsound1.isPlaying == false)
        {
            backsound1.Play();
        }
        else if (backsound1On == false && backsound1.isPlaying == true)
        {
            backsound1.Stop();
            
        } 

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
        
        //Tidak memunculkan puzzle yang telah diambil
        PuzzleCollectible.alreadyTaken = data.AlreadyTaken;
        PuzzleCollectible2.alreadyTaken2 = data.AlreadyTaken2;
        PuzzleCollectible3.alreadyTaken3 = data.AlreadyTaken3;
        PuzzleCollectible4.alreadyTaken4 = data.AlreadyTaken4;
        PuzzleCollectible5.alreadyTaken5 = data.AlreadyTaken5;

        //Menyimpan puzzle yang telah diambil
        Puzzle.PuzzleCollect = data.TotalPuzzle;
        puzzleTotal = data.TotalPuzzle;


        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        lastCheckPointPos = transform.position;
    }

    public void NewGame()
    {
        StatusNewGame.statnewgame = true;
        SceneManager.LoadScene(3);
    }


    public void LoadGame()
    {

        if (SaveSystem.LoadPlayer() == null)
        {
           
        } else
        {
            StatusNewGame.statnewgame = false;
            LoadPlayer();
            SceneManager.LoadScene(1);
        }
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            backsound1On = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            backsound1On = false;
        }
    }
}

