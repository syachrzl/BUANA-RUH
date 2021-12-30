using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallByForce : MonoBehaviour
{
    [SerializeField] private float forceMax = 100f;

    private Rigidbody2D rb;
    private float currentlyForce;
    private float force;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (force >= forceMax)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.relativeVelocity.magnitude);
        currentlyForce = collision.relativeVelocity.magnitude;
        force = force + currentlyForce;
    }
}
