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

  public void OnButtonPress()
  {

  }

  public void AddItem(string key)
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

  public void RemoveItem(string key)
  {
    if (Items.ContainsKey(key))
    {
      if (Items[key] == 1)
      {
        Items.Remove(key);
        return;
      }

      Items[key] = Items[key] - 1;
    }
  }

  public void CleanItems()
  {
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

  public bool CanCookEggs()
  {
    return Items.ContainsKey("Eggs") && Items.ContainsKey("Spatula") && Items.ContainsKey("Bowl");
  }

  public bool CookEggs()
  {
    if (CanCookEggs())
    {
      RemoveItem("Spatula");
      RemoveItem("Bowl");
      RemoveItem("Eggs");
      AddItem("DirtySpatula");
      AddItem("DirtyBowl");
      AddItem("CookedEggs");
    }

    return false;
  }

  // Update is called once per frame
  void Update()
  {

  }

  private void OnGUI()
  {
    int i = 1;
    GUI.Label(new Rect(20, 300, 150, 25), "Inventory");
    foreach (KeyValuePair<string, uint> entry in Items)
    {
      GUI.Label(new Rect(20, 300 + i * 15, 150, 25), entry.Key + ": " + entry.Value);
      i++;
    }
  }
}
