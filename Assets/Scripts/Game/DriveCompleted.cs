using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveCompleted : MonoBehaviour
{
    //Checks to see when the level is over
    public float timeLeft = 10;
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("NightTime");
            Debug.Log("MY MOM");
        }

    }
}
