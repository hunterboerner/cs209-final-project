using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBehavior : MonoBehaviour
{
  public bool isOn = false;
  public GameObject Fire;
  public uint dirtyLevel = 0;
  private GameBehavior gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
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
    else
      gameManager.StoveClean = true;
  }

  public void TurnOnStove()
  {
    isOn = true;
    if (dirtyLevel >= 5) {
      Fire.GetComponent<FireBehavior>().turnOn();
      gameManager.FireDanger = true;
    }
  }

  public void TurnOffStove()
  {
    isOn = false;
    Fire.GetComponent<FireBehavior>().turnOff();
  }
}
