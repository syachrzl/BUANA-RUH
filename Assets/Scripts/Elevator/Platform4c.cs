using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform4c : MonoBehaviour
{
    public Tuas4c tuas;
    // untuk arah gerakan 
    public GameObject wayPoint1;
    public GameObject wayPoint2;

    public float speed = 2f;
    void Update()
    {

        if (tuas.statusPlat == true && tuas.kodePlat2 == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (tuas.statusPlat == false && tuas.kodePlat2 == true)
        {

            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }


    }
}
