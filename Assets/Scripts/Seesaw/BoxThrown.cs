using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxThrown : MonoBehaviour
{
    public Rigidbody2D treeRb;
    public TriggerPlayer tp;
    public TriggerBox tb;
    public GameObject box;
    public BoxPull bp;

    [HideInInspector] public Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }


    private void Update()
    {
        if (tp.statusPlayer == true && tb.statusBox == true)
        {
            anim.enabled = true;
            treeRb.bodyType = RigidbodyType2D.Dynamic;
            bp.beingPushed = true;
        } 
    }

}
