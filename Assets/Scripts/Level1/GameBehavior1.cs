using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameBehavior1 : MonoBehaviour
{
    public bool showWinScreen = false;
    public bool showLoseScreen = false;
    
    void Start()
    {
        Time.timeScale = 1.0f;
        showWinScreen = false;
        showLoseScreen = false;
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
    private bool sinkOn = false;
    public bool SinkOn
    {
        get { return sinkOn; }
        set {
            sinkOn = value;
            Debug.LogFormat("SinkOn: {0}", sinkOn);
        }
    }
    private bool dishesClean = false;
    public bool DishesClean
    {
        get { return dishesClean; }
        set {
            dishesClean = value;
            Debug.LogFormat("DishesClean: {0}", dishesClean);

            if (dishesClean && stoveClean)
            {
                showWinScreen = true;
                Time.timeScale = 0f;
            }
        }
    }
    private bool stoveClean = false;
    public bool StoveClean
    {
        get { return stoveClean; }
        set {
            stoveClean = value;
            Debug.LogFormat("StoveClean: {0}", stoveClean);

            if (dishesClean && stoveClean)
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
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1.0f;
    }
    void MainMenu()
    {
        SceneManager.LoadScene("Home");
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }


    void OnGUI()
    {
        GUI.Box(new Rect(20, 20, 150, 25), "Score: " +
            score);
        GUI.Box(new Rect(20, 50, 150, 25), "Sink turned on: " +
            sinkOn);
        GUI.Box(new Rect(20, 80, 150, 25), "Dishes Cleaned: " +
            dishesClean);
        GUI.Box(new Rect(20, 110, 150, 25), "Stove Cleaned: " +
            stoveClean);
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
