using UnityEngine;

public class Platform : MonoBehaviour
{
    public Tuas tuas;
    // untuk arah gerakan 
    public GameObject wayPoint1;
    public GameObject wayPoint2;

    [SerializeField] private AudioSource elevatorSound;
    private bool elevatorSFXon; 

    public float speed = 2f;

    void Update()
    {
        if (tuas.statusPlat == true && tuas.kodePlat1 == true)
        {

            elevatorSFXon = true;

            if (elevatorSFXon == true && elevatorSound.isPlaying == false)
            {
                elevatorSound.Play();
            }
            else if (elevatorSFXon == false && elevatorSound.isPlaying == true)
            {
                elevatorSound.Stop();
            }
            else if(transform.position.y > 146)
            {
                elevatorSound.Stop();
            }

            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (tuas.statusPlat == false && tuas.kodePlat1 == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }


    }
}