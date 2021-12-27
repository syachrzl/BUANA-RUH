using UnityEngine;

public class PuzzleCollectible2 : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    public static bool alreadyTaken2 = false;


    private void Awake()
    {
        if (alreadyTaken2 == true)
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
            alreadyTaken2 = true;
        }
    }

}
