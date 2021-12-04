using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehavior : MonoBehaviour
{
  public float scaleSpeed = 0.01F;
  public bool Enabled = false;
  // Start is called before the first frame update
  void Start()
  {
    gameObject.GetComponent<ParticleSystem>().Stop();
  }

  
  // Update is called once per frame
  void Update()
  {
    if (Enabled)
      transform.localScale += new Vector3(scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime, scaleSpeed * Time.deltaTime);
  }

  public void turnOn()
  {
    Enabled = true;
    gameObject.GetComponent<ParticleSystem>().Play();
  }

  public void turnOff()
  {
    Enabled = false;
    gameObject.GetComponent<ParticleSystem>().Stop(); 
  }
}
