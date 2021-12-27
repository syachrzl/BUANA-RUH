using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrushedGround : MonoBehaviour
{
    public bool crush = false;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (crush == true)
        {
            gameObject.SetActive(true);
            anim.SetBool("crushed", true);
        }
    }
}
