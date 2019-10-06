using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveCompleted : MonoBehaviour
{
    //Checks to see when the level is over
    public float timeLeft = 10;
    void OnGUI()
    {
        timeLeft -= Time.deltaTime;

        GUI.Label(new Rect(Screen.width / 4, Screen.height - 100, 300f, 50f), "Time: " + timeLeft);

        if (timeLeft < 0)
        {
            SceneManager.LoadScene("CarCutScene");
        }

    }
}
