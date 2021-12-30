using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] private float speed = 25f;
    [SerializeField] private float timeSpawn = 2f;
    [SerializeField] private float timeStay = 5f;

    [SerializeField] private Transform target1;
    [SerializeField] private Transform target2;

    private bool statusAtas = true;
    private bool statusBawah;



    private void Update()
    {
        if (statusAtas == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target1.position, speed * Time.deltaTime);
        }
        else if (statusBawah == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target2.position, speed * Time.deltaTime);
        }

        if (transform.position.y == target2.position.y && statusAtas == false)
        {
            Invoke("Keatas", timeSpawn);
        }
        if (transform.position.y == target1.position.y && statusBawah == false)
        {
            Invoke("Kebawah", timeStay);

        }

    }

    void Kebawah()
    {
        statusBawah = true;
        statusAtas = false;
    }
    void Keatas()
    {
        statusAtas = true;
        statusBawah = false;
    }

}
