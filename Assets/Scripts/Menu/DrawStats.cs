using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class DrawStats : MonoBehaviour
{
    public float health;
    public float hunger;
    public float Sleep;
    public float health1;
    public float hunger1;
    public float Sleep1;
    public float health2;
    public float hunger2;
    public float Sleep2;

    private float margin = 80;

    // Start is called before the first frame update
    void OnGUI()
    {
        GUI.skin.label.fontSize = 32;
        GUI.skin.label.normal.textColor = Color.white;

        GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 50, 400, 100),
            "You killed " + GameSingleton.Instance.zombieKills + " zombie" +
            (GameSingleton.Instance.zombieKills == 1 ? "" : "s") + ".");
        /*GUI.Label(new Rect(Screen.width / 6 - margin, Screen.height / 3, 250, 100), "MONICA");
        GUI.Label(new Rect(Screen.width / 6 - margin, (Screen.height / 3) + 50, 250, 100), "Health: " + health);
        GUI.Label(new Rect(Screen.width / 6 - margin, (Screen.height / 3) + 100, 250, 100), "Hunger: " + hunger);
        GUI.Label(new Rect(Screen.width / 6 - margin, (Screen.height / 3) + 150, 250, 100), "Sleep: " + Sleep);

        GUI.Label(new Rect(Screen.width / 2 - margin, Screen.height / 3, 250, 100), "SAMUEL");
        GUI.Label(new Rect(Screen.width / 2 - margin, (Screen.height / 3) + 50, 250, 100), "Health: " + health1);
        GUI.Label(new Rect(Screen.width / 2 - margin, (Screen.height / 3) + 100, 250, 100), "Hunger: " + hunger1);
        GUI.Label(new Rect(Screen.width / 2 - margin, (Screen.height / 3) + 150, 250, 100), "Sleep: " + Sleep1);

        GUI.Label(new Rect(Screen.width * 5/6 - margin, Screen.height / 3, 250, 100), "PENELOPE");
        GUI.Label(new Rect(Screen.width * 5/6 - margin, (Screen.height / 3) + 50, 250, 100), "Health: " + health2);
        GUI.Label(new Rect(Screen.width * 5/6 - margin, (Screen.height / 3) + 100, 250, 100), "Hunger: " + hunger2);
        GUI.Label(new Rect(Screen.width * 5/6 - margin, (Screen.height / 3) + 150, 250, 100), "Sleep: " + Sleep2);*/
    }

    // Update is called once per frame
    void Update()
    {
    }
}