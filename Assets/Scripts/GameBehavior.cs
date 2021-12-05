using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private bool sinkOn = false;

    public bool showWinScreen = false;

    public bool showLoseScreen = false;

    public bool Level1Goal
    {
        get { return sinkOn; }
        set {
            sinkOn = value;
            Debug.LogFormat("SinkOn: {0}", sinkOn);

            if (sinkOn)
            {
                showWinScreen = true;

                Time.timeScale = 0f;
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Sink turned on: " +
            sinkOn);

        if (showWinScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "WIN (Click to restart)"))
            {
                RestartLevel();
            }
        }
        if (showLoseScreen)
        {
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "LOSE (Click to restart)"))
            {
                RestartLevel();
            }
        }
    }
}
