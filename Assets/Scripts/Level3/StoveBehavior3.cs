using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBehavior3 : MonoBehaviour
{
  public bool isOn = false;
  public GameObject Fire;
  public uint dirtyLevel = 5;
  private GameBehavior3 gameManager;

  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior3>();
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
    else {
      if (!gameManager.StoveClean) {
        gameManager.StoveClean = true;
        gameManager.Score+= 20;
      }
    }
  }

  public void TurnOnStove()
  {
    isOn = true;
    Fire.GetComponent<FireBehavior>().turnOn();
    if (dirtyLevel >= 5) {
      gameManager.FireDanger = true;
    }
    if (!gameManager.StoveOn) {
      gameManager.StoveOn = true;
      gameManager.Score+= 10;
    }
  }

  public void TurnOffStove()
  {
    isOn = false;
    Fire.GetComponent<FireBehavior>().turnOff();
    if (gameManager.EggsCooked && !gameManager.StoveOff) {
      gameManager.StoveOff = true;
      gameManager.Score+= 10;
    }
  }
}
