using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDie : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private Transform player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
                
        }
    }
}