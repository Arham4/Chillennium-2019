using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SpawnNature : MonoBehaviour
{
    public GameObject Trees;
    private bool spawnObject = true;
    public bool mountain = false;
    public bool sign = false;
    public float ObstacleSpeed = 2.5f;
    private float _actualSpeed;

    private void Start()
    {
        _actualSpeed = ObstacleSpeed;
    }

    void Update()
    {
        if (GameSingleton.Instance.currentSongType == Radio.SongType.Pump)
        {
            _actualSpeed = ObstacleSpeed * 2f;
        }
        else
        {
            _actualSpeed = ObstacleSpeed;
        }
        
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - _actualSpeed);

        if (transform.position.z < -60)
        {
            if (mountain == false)
                transform.position = new Vector3(507.2f + Random.Range(-268f, 332f), transform.position.y, 1000f + Random.Range(0, 750f));
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, 1000f);
        }

        var posX = GameObject.Find("Car").transform.position;
        var gObj = GameObject.Find("Car");

        if (gObj)
        {
            posX = gObj.transform.position;

            if (transform.position.x - posX.x <= 15f && transform.position.x - posX.x >= -15f)
            {
                if (transform.position.z - posX.z <= 3f && transform.position.z - posX.z >= -3f)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }
        }
    }
}