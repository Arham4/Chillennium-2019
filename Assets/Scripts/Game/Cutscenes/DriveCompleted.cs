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

        GUIStyle style = GUI.skin.label;
        style.fontSize = 36;
        style.normal.textColor = Color.black;
        style.wordWrap = false;
        GUI.Label(new Rect((float) (Screen.width / 10.0), 100, 300f, 100f), "Time: " + timeLeft, style);
        if (GameSingleton.Instance.currentSongType != Radio.SongType.Regular)
        {
            GUI.Label(new Rect((float) (Screen.width / 10.0), 155, 500f, 50f), "Perk time left: " + Radio.RevertTime, style);
        }
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("CarCutScene");
        }

    }
}
