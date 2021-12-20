using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDie : MonoBehaviour
{ 
    public static float damage = 1;
    [SerializeField] private Transform player;

    void Awake()
    {
        damage = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            //collision.GetComponent<Health>().TakeDamage(damage);
                
        }
    }
}