using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWayIntIndex = 0;

    [SerializeField] private float speed = 12f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWayIntIndex].transform.position, transform.position) < .1f)
        {
            currentWayIntIndex++;
            if (currentWayIntIndex >= waypoints.Length)
            {
                currentWayIntIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWayIntIndex].transform.position, Time.deltaTime * speed);
    }
}
