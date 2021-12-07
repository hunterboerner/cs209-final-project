using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStoveBehavior3 : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private string guiText2;
  private int timer = 0;
  private int timer2 = 0;
  private bool showText = false;
  private bool showCookPrompt = false;
  private InventoryBehavior3 Inventory;
  private GameBehavior3 gameManager;
  // Start is called before the first frame update
  void Start()
  {
    Inventory = GameObject.Find("PlayerGroupNew").GetComponent<InventoryBehavior3>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior3>();
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      StoveBehavior3 hitItem = hitInfo.collider.GetComponent<StoveBehavior3>();
      if (hitItem != null)
      {
        showText = true;
        if (hitItem.isOn)
        {
          if (Input.GetKey(KeyCode.E))
            timer += 1;
          else
            timer = 0;

          if (Input.GetKey(KeyCode.C))
            timer2 += 1;
          else
            timer2 = 0;

          if (timer >= 200)
          {
            hitItem.TurnOffStove();
          }

          if (timer2 >= 200)
          {
            Inventory.CookEggs();
            showCookPrompt = false;
          }
          guiText = "Hold E to turn off the stove";

          if (Inventory.CanCookEggs()) {
            guiText2 = "Hold C to cook eggs";
            showCookPrompt = true;
          }
          else
            guiText2 = "";
        }
        else
        {
          if (Input.GetKey(KeyCode.E)) {
            timer += 1;
            Debug.LogFormat("Turning Stove on {0}", timer);
          }
          else
            timer = 0;

          if (timer >= 200)
          {
            Debug.LogFormat("Stove on");
            hitItem.TurnOnStove();
          }

          guiText = "Hold E to turn on the stove";
          guiText2 = "";
          showCookPrompt = false;
        }

      }
      else
      {
        guiText = "";
        guiText2 = "";
        showText = false;
        timer = 0;
        timer2 = 0;
      }
    }
    else
    {
      guiText = "";
      guiText2 = "";
      showText = false;
      timer = 0;
      timer2 = 0;
    }
  }

  private void OnGUI()
  {
    if (showText && !gameManager.showWinScreen && !gameManager.showLoseScreen) {
      GUI.Box(new Rect(Screen.width/2 - 100, 
        Screen.height/2 - 50, 
        200, 25), guiText);
      if (showCookPrompt) {
        GUI.Box(new Rect(Screen.width/2 - 100, 
          Screen.height/2 - 80, 
          200, 25), guiText2);
      }
    }
  }
}
