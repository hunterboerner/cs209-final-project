using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanStoveBehavior : MonoBehaviour
{
  // based on https://www.youtube.com/watch?v=jjBeh2xLckA
  public Camera Camera;
  public LayerMask layerMask;
  private string guiText;
  private int timer = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    Ray ray = Camera.ViewportPointToRay(Vector3.one / 2f);
    Debug.DrawRay(ray.origin, ray.direction * 2f, Color.red);
    RaycastHit hitInfo;
    if (Physics.Raycast(ray, out hitInfo, 2f, layerMask))
    {
      StoveBehavior hitItem = hitInfo.collider.GetComponent<StoveBehavior>();
      if (hitItem != null)
      {
        if (hitItem.isOn)
        {
          // TODO This is a lose condition
          guiText = "Hold Q to clean stove";
        }
        else
        {
          if (Input.GetKey(KeyCode.Q))
            timer += 1;
          else
            timer = 0;

          if (timer == 200)
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
        timer = 0;
      }
    }
    else
    {
      guiText = "";
      timer = 0;
    }
  }

  private void OnGUI()
  {
    GUI.Box(new Rect(20, 200, 150, 25), guiText);
  }
}
