using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundCollapse : MonoBehaviour
{
    public GameObject GroundCollaps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(GroundCollaps);
        }
    }
}
