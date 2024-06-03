using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public static bool gamePause = false;
    public GameObject pauseMenu;
    void Start()
    {
        gamePause = false;
    }

    // Update is called once per frame
    void Update()
    {
        PauseByClick();
        if (gamePause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
    public void PauseByClick()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            gamePause = true;
            pauseMenu.SetActive(true);
            CrossHair.StandartCursor();
        }
    }
    public void ReturnPause(bool value)
    {
        gamePause = value;
    }
}
