using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCollaps : MonoBehaviour
{
    [SerializeField] private float speedTranslate = 3f;
    [SerializeField] private float speedRotation = 90f;

    private float rotZ = 0f;
    private bool statusRotation = true;
    public bool statusCollaps;

    [SerializeField] private GameObject target;

    private void Update()
    {
        if (statusCollaps == true)
        {
            if (statusRotation == true)
            {
                Putar();
            }
            Translate();
        }
        if (rotZ <= -155f)
        {
            statusRotation = false;
        }
    }
    void Putar()
    {
        rotZ += -Time.deltaTime * speedRotation;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
    void Translate()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speedTranslate);
    }
}
