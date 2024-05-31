using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gamePause = false;
    void Start()
    {
        gamePause = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
