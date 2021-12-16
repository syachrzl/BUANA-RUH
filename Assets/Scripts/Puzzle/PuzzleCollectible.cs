using UnityEngine;

public class PuzzleCollectible : MonoBehaviour
{
    [SerializeField] private float puzzleValue;
    //[SerializeField] public float idPuzzle;
    //public static float[] AllUnique;
    //public static float unique = 0;
    public static bool alreadyTaken;


    private void Awake()
    {
        //Jika sudah diambil itemnya , ketika load atau restart maka hilang
       // foreach(float all in AllUnique) { 
            //if (all == unique)
          //  {
         //       gameObject.SetActive(false);
         //   } else
        //    {
        //        gameObject.SetActive(true);
        //    }
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Puzzle>().AddPuzzle(puzzleValue);
            gameObject.SetActive(false);
            alreadyTaken = true;

            //Mengambil idPuzzle dimasukan kedalam variabel unique , untuk disimpan
            //unique = idPuzzle;
        }
    }

}
