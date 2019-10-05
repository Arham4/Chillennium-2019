using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieDecoration : MonoBehaviour
{
    private int counter = 0;
    private bool up;
    private float speed = 10;

    // Update is called once per frame
    void Update()
    {
        if (up)
        {
            counter++;
            transform.Translate(0, counter / speed, 0);
        }
        else
        {
            counter--;
            transform.Translate(0, counter / speed, 0);
        }

        if (counter > 5)
        {
            counter = 0;
            up = false;
        }
        if (counter < -5)
        {
            counter = 0;
            up = true;
        }

    }
}
