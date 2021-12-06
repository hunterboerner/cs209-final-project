using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkInteractionBehavior : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private bool showText = false;
  private int timer = 0;
  private InventoryBehavior Inventory;
  private GameBehavior gameManager;
  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    Inventory = GameObject.Find("PlayerGroupNew").GetComponent<InventoryBehavior>();
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      SinkBehavior hitItem = hitInfo.collider.GetComponent<SinkBehavior>();
      if (hitItem != null)
      {
        showText = true;
        if (Input.GetKey(KeyCode.E))
        {
          timer += 1;
          if (!gameManager.SinkOn) {
            gameManager.SinkOn = true;
            gameManager.Score+= 10;
          }
        }
        else
          timer = 0;

        if (timer == 500)
        {
          Debug.Log("Cleaning items");
          Inventory.CleanItems();
        }

        guiText = "Hold E to clean your items";
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
    if (showText) {
      GUI.Box(new Rect(Screen.width/2 - 100, 
        Screen.height/2 - 50, 
        200, 25), guiText);
    }
  }
}
