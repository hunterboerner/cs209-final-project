using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanStoveBehavior2 : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private int timer = 0;
  private bool showText = false;
  private GameBehavior2 gameManager;
  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior2>();
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      StoveBehavior2 hitItem = hitInfo.collider.GetComponent<StoveBehavior2>();
      if (hitItem != null)
      {
        if (hitItem.isOn)
        {
        }
        else
        {
          showText = true;
          if (Input.GetKey(KeyCode.Q))
            timer += 1;
          else
            timer = 0;

          if (timer >= 200)
          {
            Debug.Log("Cleaning the stove!");
            hitItem.CleanStove();
            timer = 0;
          }

          guiText = "Hold Q to clean stove";
        }

      }
      else
      {
        guiText = "";
        showText = false;
        timer = 0;
      }
    }
    else
    {
      guiText = "";
      showText = false;
      timer = 0;
    }
  }

  private void OnGUI()
  {
    if (showText && !gameManager.showWinScreen && !gameManager.showLoseScreen) {
      GUI.Box(new Rect(Screen.width/2 - 100, 
        Screen.height/2 - 20, 
        150, 25), guiText);
    }
  }
}
