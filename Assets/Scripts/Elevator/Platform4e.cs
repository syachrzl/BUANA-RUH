using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform4e : MonoBehaviour
{
    public Tuas4e tuas;
    // untuk arah gerakan 
    public GameObject wayPoint1;
    public GameObject wayPoint2;

    public float speed = 2f;
    void Update()
    {

        if (tuas.statusPlat == true && tuas.kodePlat0 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (tuas.statusPlat == false && tuas.kodePlat0 == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }


    }
}
