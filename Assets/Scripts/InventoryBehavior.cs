using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehavior : MonoBehaviour
{
  public Dictionary<string, uint> Items;
  public uint numSpatula = 1;
  public uint numEggs = 3;
  public uint numBowl = 1;
  // Start is called before the first frame update
  void Start()
  {
    Items = new Dictionary<string, uint>();
    Items["Bowl"] = numBowl;
    Items["Eggs"] = numEggs;
    Items["Spatula"] = numSpatula;
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

  private void OnGUI()
  {
    int i = 1;
    GUI.Label(new Rect(20, 300, 150, 25), "Inventory");
    Debug.LogFormat("Num items: {0}", Items.Count);
    foreach (KeyValuePair<string, uint> entry in Items)
    {
      Debug.Log("printing value");
      GUI.Label(new Rect(20, 300 + i * 15, 150, 25), entry.Key + ": " + entry.Value);
      i++;
    }
  }
}
