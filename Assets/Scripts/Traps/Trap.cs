using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public PlayerMovement pm;

    // untuk arah gerakan 
    public GameObject wayPoint1;
    public GameObject wayPoint2;
    [SerializeField] private float speed;

    void Update()
    {
        if (pm.statusTraps == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (pm.statusTraps == false)
        {

            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }
    }
}
