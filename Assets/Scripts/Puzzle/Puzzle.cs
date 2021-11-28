using UnityEngine;
using UnityEngine.UI;

public class Puzzle : MonoBehaviour
{
    [SerializeField] private float startingPuzzle;
    [SerializeField] private float startEmptyPuzzle;
      private Animator anim;
    private bool dead;


    public float currentPuzzle { get; private set; }
    public float EmptyPuzzle { get; private set; }


    private void Awake()
    {
        currentPuzzle = startingPuzzle;
        EmptyPuzzle = startEmptyPuzzle;
        anim = GetComponent<Animator>();
    }

    public void AddPuzzle(float _value)
    {
        currentPuzzle = Mathf.Clamp(currentPuzzle + _value, 0, startEmptyPuzzle);

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
       // if (Input.GetKeyDown(KeyCode.E))
           // TakePuzzle(1);
     }
}
