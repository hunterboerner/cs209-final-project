using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameBehavior2 : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLoseScreen = false;
    
    void Start()
    {
        Time.timeScale = 1.0f;
        showWinScreen = false;
        showLoseScreen = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private int score = 0;
    public int Score
    {
        get { return score; }
        set {
            score = value;
            Debug.LogFormat("Score: {0}", score);
        }
    }
    private bool getEggs = false;
    public bool GetEggs
    {
        get { return getEggs; }
        set {
            getEggs = value;
            Debug.LogFormat("GetEggs: {0}", getEggs);
        }
    }
    private bool stoveOn = false;
    public bool StoveOn
    {
        get { return stoveOn; }
        set {
            stoveOn = value;
            Debug.LogFormat("StoveOn: {0}", stoveOn);
        }
    }
    private bool eggsCooked = false;
    public bool EggsCooked
    {
        get { return eggsCooked; }
        set {
            eggsCooked = value;
            Debug.LogFormat("DishesClean: {0}", eggsCooked);
        }
    }
    private bool stoveOff = false;
    public bool StoveOff
    {
        get { return stoveOff; }
        set {
            stoveOff = value;
            Debug.LogFormat("StoveOff: {0}", stoveOff);
            if (stoveOff && eggsCooked)
            {
                showWinScreen = true;
                Time.timeScale = 0f;
            }
        }
    }
    private bool fireDanger = false;
    public bool FireDanger
    {
        get { return fireDanger; }
        set {
            fireDanger = value;
            Debug.LogFormat("FireDanger: {0}", fireDanger);

            if (fireDanger)
            {
                showLoseScreen = true;
                Time.timeScale = 0f;
            }
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Level2");
        Time.timeScale = 1.0f;
    }
    void MainMenu()
    {
        SceneManager.LoadScene("Home");
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level3");
    }


    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Score: " +
            score);
        GUI.Box(new Rect(20, 50, 200, 25), "Get eggs from fridge: " +
            getEggs);
        GUI.Box(new Rect(20, 80, 200, 25), "Turn the stove on: " +
            stoveOn);
        GUI.Box(new Rect(20, 110, 200, 25), "Cook eggs on stove: " +
            eggsCooked);
        GUI.Box(new Rect(20, 140, 200, 25), "Turn the stove off: " +
            stoveOff);
        if (showWinScreen)
        {
            Cursor.lockState = CursorLockMode.None;
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "WIN (Click to restart)"))
            {
                RestartLevel();
            }
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 150, 200, 100), "(Click for next level)"))
            {
                NextLevel();
            }
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 250, 200, 100), "(Click for main menu)"))
            {
                MainMenu();
            }
        }
        if (showLoseScreen)
        {
            Cursor.lockState = CursorLockMode.None;
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 50, 200, 100), "LOSE (Click to restart)"))
            {
                RestartLevel();
            }
            if (GUI.Button(new Rect(Screen.width/2 - 100,
                Screen.height/2 - 150, 200, 100), "(Click for main menu)"))
            {
                MainMenu();
            }
        }
    }
}
