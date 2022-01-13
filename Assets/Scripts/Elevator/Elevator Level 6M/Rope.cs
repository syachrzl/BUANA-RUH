using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private Vector3 temp;
    public Tuas6m tuas;

    private void Update()
    {
        if (tuas.statusPlat == true)
        {
            // memendek
            Stretch(-1);
        }
        else if (tuas.statusPlat == false)
        {
            // memanjang
            Stretch(1);
        }

    }

    void Stretch(int i)
    {
        temp = transform.localScale;
        temp.y += Time.deltaTime * speed * i;
        if (temp.y <= 3.5f)
        {
            temp.y = 3.5f;
        }
        else if (temp.y >= 19f)
        {
            temp.y = 19f;
        }
        transform.localScale = new Vector3(transform.localScale.x, temp.y, transform.localScale.z);
    }
}
