using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCar : MonoBehaviour
{
    private float counter = 0;

    // Update is called once per frame
    void Update()
    {
        counter += .08f;
        transform.position = new Vector3(transform.position.x + counter, transform.position.y, transform.position.z);

        if(transform.position.x > 1500f)
        {
            SceneManager.LoadScene("NightTime");
        }
    }
}
