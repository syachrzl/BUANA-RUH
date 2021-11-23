using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMove : MonoBehaviour
{
    public GameObject pointWay;
    public float speed = 2f;
    public DoorDetect dt;

    void Update()
    {
        if (dt.status == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, pointWay.transform.position, speed * Time.deltaTime);
        }
    }

}