using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectGroundCollapse : MonoBehaviour
{
    public GameObject GroundCollaps;
    public GameObject CrushedGround;
    public CrushedGround cs;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(GroundCollaps);
            CrushedGround.SetActive(true);
            cs.crush = true;
        }
    }
}
