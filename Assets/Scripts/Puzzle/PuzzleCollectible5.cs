using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollectible5 : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    public static bool alreadyTaken5 = false;

    private void Awake()
    {
        if (alreadyTaken5 == true)
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
            alreadyTaken5 = true;
        }
    }
}
