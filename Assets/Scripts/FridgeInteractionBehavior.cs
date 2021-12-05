using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeInteractionBehavior : MonoBehaviour
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
      FridgeBehavior hitItem = hitInfo.collider.GetComponent<FridgeBehavior>();
      if (hitItem != null)
      {
        if (Input.GetKey(KeyCode.E))
          timer += 1;
        else
          timer = 0;

        if (timer == 200)
        {
          // TODO Open the fridge inventory GUI
        }

        guiText = "Hold E to open the fridge";

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
    GUI.Box(new Rect(20, 300, 150, 25), guiText);
  }
}
