using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRun : MonoBehaviour
{
    [SerializeField] private PlayerMovement pm;

    [Range(0.01f, 1.5f)] public float timeDuration = 1f;
    private float clickTimeRight, clickTimeLeft;
    private float timeLastRight, timeLastLeft;

    private void Update()
    {
        Kanan();
        Kiri();
    }

    void Kanan()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) )
        {
            timeLastRight = Time.time - clickTimeRight;
            if (timeLastRight <= timeDuration)
            {
                transform.localScale = new Vector3(1, 1, 1);
                pm.statusRun = true;
                pm.statusWalk = false;
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
                pm.statusWalk = true;
                pm.statusRun = false;
            }
            clickTimeRight = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            pm.statusRun = false;
            pm.statusWalk = true;
        }
    }

    void Kiri()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            timeLastLeft = Time.time - clickTimeLeft;
            if (timeLastLeft <= timeDuration)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                pm.statusRun = true;
                pm.statusWalk = false;
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
                pm.statusWalk = true;
                pm.statusRun = false;
            }
            clickTimeLeft = Time.time;
        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            pm.statusRun = false;
            pm.statusWalk = true;
        }
    }
}
