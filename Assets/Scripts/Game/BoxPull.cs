using UnityEngine;
using System.Collections;

public class BoxPull : MonoBehaviour
{
    public bool beingPushed;
    float xPos;

    //Audio
    public AudioSource audio_PushPull;

    void Start()
    {
        xPos = transform.position.x;
    }

    void Update()
    {
        if (beingPushed == false)
        {
            transform.position = new Vector3(xPos, transform.position.y);
            //audio_PushPull.Play();
        }
        else
            xPos = transform.position.x;
            
    }

}