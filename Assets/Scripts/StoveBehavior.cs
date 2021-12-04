using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBehavior : MonoBehaviour
{
  public bool isOn = false;
  public GameObject Fire;
  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void TurnOnStove()
  {
    isOn = true;
    Fire.GetComponent<FireBehavior>().turnOn();
  }

  public void TurnOffStove()
  {
    isOn = false;
    Fire.GetComponent<FireBehavior>().turnOff();
  }
}
