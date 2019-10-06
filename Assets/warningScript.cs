using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

public class warningScript : MonoBehaviour
{
    private GameObject warning;
    private float counter = 0;
    private bool add = true;
    private float distance = 350;

    private void Start()
    {
        warning = GameObject.Find("Warning");
    }

    void Update()
    {
        if (GameSingleton.Instance.currentView != View.Backseat)
        {
            add = true;
            warning.SetActive(false);
        }
        
        if(counter >= distance && GameSingleton.Instance.currentView == View.Backseat)
        {
            counter = 0;
            warning.SetActive(true);
            add = false;
        }

        if(add)
            counter++;
    }
}
