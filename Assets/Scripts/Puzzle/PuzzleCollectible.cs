using UnityEngine;

public class PuzzleCollectible : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    public static bool alreadyTaken;


    private void Awake()
    {
        //Jika sudah diambil itemnya , ketika load atau restart maka hilang
        if(alreadyTaken == true)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Puzzle>().AddPuzzle(puzzleValue);
            gameObject.SetActive(false);
            alreadyTaken = true;
        }
    }

}
