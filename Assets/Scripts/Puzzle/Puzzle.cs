using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private float startingPuzzle;
    [SerializeField] private float startEmptyPuzzle;
    public static float PuzzleCollect;
    private Animator anim;
    private bool dead;

    //Menampilkan puzzle yang sudah didapatkan
    public float currentPuzzle { get; private set; }
    //Menampilkan puzzle kosong
    public float EmptyPuzzle { get; private set; }


    private void Awake()
    {

        //if(PuzzleCollect > 0 )
        //{
        //    currentPuzzle = PuzzleCollect;
        //}

        //Save Puzzle/Light yang sudah didapatkan
        if (PlayerManager.puzzleTotal > 0 || PuzzleCollect > 0)
        {
            currentPuzzle = PlayerManager.puzzleTotal;
        } else {
            currentPuzzle = startingPuzzle;
        }
        
        EmptyPuzzle = startEmptyPuzzle;
        anim = GetComponent<Animator>();
    }

    public void AddPuzzle(float _value)
    {
        currentPuzzle = Mathf.Clamp(currentPuzzle + _value, 0, startEmptyPuzzle);
        PuzzleCollect = currentPuzzle;
        if (EmptyPuzzle == 5)
        {
            //Light Keluar
        }
    }


    public void TakePuzzle(float _damage)
    {
        currentPuzzle = Mathf.Clamp(currentPuzzle - _damage, 0, startEmptyPuzzle);

    }

     private void Update()
    {
        PlayerManager.puzzleTotal = PuzzleCollect;
    }
}
