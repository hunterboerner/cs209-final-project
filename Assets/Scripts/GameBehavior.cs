using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameBehavior : MonoBehaviour
{
    private int _goalsCollected = 0;
    private int maxGoals = 3;

    public bool showWinScreen = false;

    public bool showLoseScreen = false;

    public int Goals
    {
        get { return _goalsCollected; }
        set {
            _goalsCollected = value;
            Debug.LogFormat("Goals: {0}", _goalsCollected);

            if (_goalsCollected >= maxGoals)
            {
                showWinScreen = true;

                Time.timeScale = 0f;
            }
        }
    }

    private int _playerHP = 3;

    public int HP
    {
        get { return _playerHP; }
        set {
            _playerHP = value;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if (_playerHP <= 0)
            {
                showLoseScreen = true;

                Time.timeScale = 0f;
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1.0f;
    }

    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Player Health: " +
            _playerHP);
        GUI.Box(new Rect(20, 50, 150, 25), "Goals Collected: " +
            _goalsCollected);
        GUI.Box(new Rect(20, 75, 150, 25), (3 - _goalsCollected) + 
            " goals remaining");

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
