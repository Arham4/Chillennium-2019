﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNature : MonoBehaviour
{
    public GameObject Trees;
    private bool spawnObject = true;
    public bool mountain = false;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5f);

        if(transform.position.z < -60)
        {
            if(mountain == false)
                transform.position = new Vector3(507.2f + Random.Range(-268f, 332f), transform.position.y, 1000f + Random.Range(0, 750f));
            else
                transform.position = new Vector3(transform.position.x, transform.position.y, 1000f);
        }
    }
}