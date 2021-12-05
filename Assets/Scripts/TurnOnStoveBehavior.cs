using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnStoveBehavior : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private string guiText2;
  private int timer = 0;
  private int timer2 = 0;
  private InventoryBehavior Inventory;
  // Start is called before the first frame update
  void Start()
  {
    Inventory = GameObject.Find("PlayerGroupNew").GetComponent<InventoryBehavior>();
  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.green);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      StoveBehavior hitItem = hitInfo.collider.GetComponent<StoveBehavior>();
      if (hitItem != null)
      {
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

          if (timer == 200)
          {
            hitItem.TurnOffStove();
          }

          if (timer2 == 200)
          {
            Inventory.CookEggs();
          }
          guiText = "Hold E to turn off the stove";

          if (Inventory.CanCookEggs())
            guiText2 = "Hole C to cook eggs";
          else
            guiText2 = "";
        }
        else
        {
          if (Input.GetKey(KeyCode.E))
            timer += 1;
          else
            timer = 0;

          if (timer == 200)
          {
            hitItem.TurnOnStove();
          }

          guiText = "Hold E to turn on the stove";
          guiText2 = "";
        }

      }
      else
      {
        guiText = "";
        guiText2 = "";
        timer = 0;
        timer2 = 0;
      }
    }
    else
    {
      guiText = "";
      guiText2 = "";
      timer = 0;
      timer2 = 0;
    }
  }

  private void OnGUI()
  {
    GUI.Box(new Rect(20, 150, 150, 25), guiText);
    GUI.Box(new Rect(20, 165, 150, 25), guiText2);
  }
}
