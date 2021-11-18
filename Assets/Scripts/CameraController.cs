﻿using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float currentPostX;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(currentPostX, transform.position.y, transform.position.z),ref velocity, speed );
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPostX = _newRoom.position.x;
    }
     
}
