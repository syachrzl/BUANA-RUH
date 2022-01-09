using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostNotActive2 : MonoBehaviour
{
    public GameObject hantu;
    public Tuas6h status;

    private void Update()
    {
        if (status.statusPlat == true)
        {
            hantu.SetActive(false);
        }
    }
}
