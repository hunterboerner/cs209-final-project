using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBehavior : MonoBehaviour
{
  public bool isOn = false;
  public GameObject Fire;
  public uint dirtyLevel = 0;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
    meshRenderer.material.SetFloat("_Metallic", (10 - dirtyLevel) / 10);
  }

  public void CleanStove()
  {
    if (dirtyLevel != 0)
      dirtyLevel--;
  }

  public void TurnOnStove()
  {
    isOn = true;
    if (dirtyLevel > 5)
      Fire.GetComponent<FireBehavior>().turnOn();
  }

  public void TurnOffStove()
  {
    isOn = false;
    Fire.GetComponent<FireBehavior>().turnOff();
  }
}
