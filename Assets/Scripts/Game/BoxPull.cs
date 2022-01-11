using UnityEngine;
using System.Collections;

public class BoxPull : MonoBehaviour
{
    public bool beingPushed;
    float xPos;
    public PlayerMovement pm;

    //Audio

    void Start()
    {
        xPos = transform.position.x;
    }

    void Update()
    {
        if (beingPushed == false)
        {
            transform.position = new Vector3(xPos, transform.position.y);
        }
        else
            xPos = transform.position.x;
            
    }

}