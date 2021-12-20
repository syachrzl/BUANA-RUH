using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectTreeCollaps : MonoBehaviour
{
    public TreeCollaps tc;
    public GameObject trigger;
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Trigger")
        {
            tc.statusCollaps = true;
            Destroy(trigger);
        }
    }
}
