using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class HandGunVisibility : MonoBehaviour
{
    private GameObject _handGun;
    
    private void Start()
    {
        _handGun = GameObject.Find("HandGun");
    }

    void Update()
    {
        if (GameSingleton.Instance.currentView != View.Backseat)
        {
            _handGun.SetActive(false);
        }
        else
        {
            _handGun.SetActive(true);
        }
    }
}
