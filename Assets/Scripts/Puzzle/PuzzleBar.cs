using UnityEngine;
using UnityEngine.UI;

public class PuzzleBar : MonoBehaviour
{
    [SerializeField] private Puzzle puzzlePlayer;
    [SerializeField] private Image totalPuzzleBar;
    [SerializeField] private Image currentPuzzleBar;

    private void Start()
    {
        totalPuzzleBar.fillAmount = puzzlePlayer.EmptyPuzzle ;
    }

    private void Update()
    { 
        currentPuzzleBar.fillAmount = puzzlePlayer.currentPuzzle / 6;
    }


}


