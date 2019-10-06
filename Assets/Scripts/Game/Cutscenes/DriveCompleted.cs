using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DriveCompleted : MonoBehaviour
{
    //Checks to see when the level is over
    public float timeLeft;
    void OnGUI()
    {
        timeLeft -= Time.deltaTime;

        GUI.skin.label.normal.textColor = Color.black;
        GUI.Label(new Rect((float) (Screen.width / 10.0), 100, 300f, 50f), "Time: " + timeLeft);
        if (GameSingleton.Instance.currentSongType != Radio.SongType.Regular)
        {
            GUI.Label(new Rect((float) (Screen.width / 10.0), 155, 500f, 50f), "Perk time left: " + Radio.RevertTime);
        }
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("CarCutScene");
        }

    }
}
