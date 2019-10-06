using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class warningScript : MonoBehaviour
{
    private GameObject warning;

    private void Start()
    {
        warning = GameObject.Find("Warning");
    }

    void Update()
    {
        if (GameSingleton.Instance.currentView != View.Backseat)
        {
            warning.SetActive(false);
        }
        else
        {
            //Collision is coming
            var posX = GameObject.Find("Obstacle").transform.position;
            var gObj = GameObject.Find("Obstacle");

            if (gObj)
            {
                posX = gObj.transform.position;
                var diff = transform.position.x - posX.x;

                if (transform.position.x - posX.x <= 15f && transform.position.x - posX.x >= -15f)
                {
                    transform.position = new Vector3(transform.position.x + diff, transform.position.y, transform.position.z);
                    warning.SetActive(true);
                }
            }
        }
    }
}
