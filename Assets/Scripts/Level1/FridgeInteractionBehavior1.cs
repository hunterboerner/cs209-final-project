using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeInteractionBehavior1 : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private int timer = 0;
  private InventoryBehavior1 Inventory;
  private bool showText = false;
  private GameBehavior1 gameManager;
  // Start is called before the first frame update
  void Start()
  {
    Inventory = GameObject.Find("PlayerGroupNew").GetComponent<InventoryBehavior1>();
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior1>();
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      FridgeBehavior hitItem = hitInfo.collider.GetComponent<FridgeBehavior>();
      if (hitItem != null)
      {
        showText = true;
        if (Input.GetKey(KeyCode.E))
          timer += 1;
        else
          timer = 0;

        if (timer >= 200)
        {
          Inventory.AddItem("Eggs");
        }

        guiText = "Hold E to take items from fridge";

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
        Screen.height/2 - 50, 
        300, 25), guiText);
    }
  }
}
