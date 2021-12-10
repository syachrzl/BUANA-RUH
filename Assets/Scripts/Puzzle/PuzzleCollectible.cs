using UnityEngine;

public class PuzzleCollectible : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    private static bool alreadyTaken;


    private void Awake()
    {
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
