using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost2 : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 5f;
    //public Tuas tuas;

    void Update()
    {
        Flip();
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        //if(tuas.statusPlat == true)
        //{
        //    gameObject.SetActive(false);
        //}

    }

    void Flip()
    {
        if (transform.position.x < target.position.x)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 1f);
        }
        else if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }



}
