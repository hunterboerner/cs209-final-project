using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehavior : MonoBehaviour
{
  public Dictionary<string, uint> Items;
  public uint numSpatula = 0;
  public uint numEggs = 0;
  public uint numBowl = 0;
  public uint numDirtyBowl = 1;
  public uint numDirtySpatula = 1;
  private GameBehavior gameManager;
  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    Items = new Dictionary<string, uint>();
    Items["Bowl"] = numBowl;
    Items["Eggs"] = numEggs;
    Items["Spatula"] = numSpatula;
    Items["DirtyBowl"] = numDirtyBowl;
    Items["DirtySpatula"] = numDirtySpatula;
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
    if (Items.ContainsKey("Bowl") &&
      Items.ContainsKey("Spatula")) 
    {
      if (!gameManager.DishesClean) {
        gameManager.DishesClean = true;
        gameManager.Score+= 20;
      }
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
      if (entry.Value != 0) {
        GUI.Label(new Rect(20, 300 + i * 15, 150, 100), entry.Key + ": " + entry.Value);
        i++;
      }
    }
  }
}
