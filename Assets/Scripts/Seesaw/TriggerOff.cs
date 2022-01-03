using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOff : MonoBehaviour
{
    public BoxThrown boxThrown;
    public Rigidbody2D boxRb;
    public GameObject box;
    public BoxPull bp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Pushable")
        {
            boxThrown.anim.enabled = false;
            Invoke("RotZ", 1f);
            bp.beingPushed = false;
        }
    }

    void RotZ()
    {
        boxRb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

}
