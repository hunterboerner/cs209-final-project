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

  public void CleanItems()
  {
    // TODO
    if (Items.ContainsKey("DirtySpatula"))
    {
      Items["Spatula"] = 1;
      Items.Remove("DirtySpatula");
    }

    if (Items.ContainsKey("DirtyBowl"))
    {
      Items["Bowl"] = 1;
      Items.Remove("DirtyBowl");
    }
  }

  public Dictionary<string, uint> GetItems()
  {
    return Items;
  }

  public bool cookEggs()
  {
    return true;
    // TODO
    // returns true if have all the items needed for cooking eggs. Uses up the items.
  }

  // Update is called once per frame
  void Update()
  {

  }
}
