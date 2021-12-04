using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehavior : MonoBehaviour
{
  public Dictionary<string, uint> Items;
  // Start is called before the first frame update
  void Start()
  {
   
  }

  void addItem(string key)
  {
    if (Items.ContainsKey(key))
    {
      Items[key] = Items[key] + 1;
    }
    else
    {
      Items[key] = 1;
    }
  }

  bool cookEggs()
  {
    // returns true if have all the items needed for cooking eggs. Uses up the items.
  }

  // Update is called once per frame
  void Update()
  {

  }
}
