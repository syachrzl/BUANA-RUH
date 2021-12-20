using UnityEngine;

public class PuzzleCollectible : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    public static bool alreadyTaken;

    //[SerializeField] private float id;


    private void Awake()
    {
        //MASIH BUG, IKUT HILANG
        if (alreadyTaken == true)
        {
            gameObject.SetActive(false);

        }
        else
        {
            gameObject.SetActive(true);
        }

    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Puzzle>().AddPuzzle(puzzleValue);
            gameObject.SetActive(false);
            alreadyTaken = true;

            //Jika item didapatkan, maka item dengan id unik ditangkap dan disimpan
            //IdPuzzle = id;
        }
    }

}
