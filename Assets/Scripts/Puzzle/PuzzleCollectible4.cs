using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleCollectible4 : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    public static bool alreadyTaken4 = false;

    private void Awake()
    {
        if (alreadyTaken4 == true)
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
            alreadyTaken4 = true;
        }
    }
}
