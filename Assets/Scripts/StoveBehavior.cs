using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveBehavior : MonoBehaviour
{
    public bool isOn = false;
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
    }

    public void TurnOffStove()
    {
      isOn = false;
    }
}
