using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Tuas tuas;
    public GameObject wayPoint1;
    public GameObject wayPoint2;
    public float speed = 2f;
    void Update()
    {

        if (tuas.statusPlat == true)
        {
            Debug.Log("plat keatas");
            transform.position = Vector2.MoveTowards(transform.position, wayPoint1.transform.position, Time.deltaTime * speed);
        }
        else if (tuas.statusPlat == false)
        {
            Debug.Log("plat kebawah");
            transform.position = Vector2.MoveTowards(transform.position, wayPoint2.transform.position, Time.deltaTime * speed);
        }


    }
}