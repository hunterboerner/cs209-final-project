using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryBehavior3 : MonoBehaviour
{
  public Dictionary<string, uint> Items;
  public uint numSpatula;
  public uint numEggs;
  public uint numBowl;
  public uint numDirtyBowl;
  public uint numDirtySpatula;
  private GameBehavior3 gameManager;
  // Start is called before the first frame update
  void Start()
  {
    gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior3>();
    Items = new Dictionary<string, uint>();
    numDirtyBowl = 1;
    numDirtySpatula = 1;
    numBowl = 0;
    numEggs = 0;
    numSpatula = 0;
    if (numBowl > 0)
      Items["Bowl"] = numBowl;
    if (numEggs > 0)
      Items["Eggs"] = numEggs;
    if (numSpatula > 0)
      Items["Spatula"] = numSpatula;
    if (numDirtyBowl > 0)
      Items["DirtyBowl"] = numDirtyBowl;
    if (numDirtySpatula > 0)
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
      if (!gameManager.EggsCooked) {
        gameManager.EggsCooked = true;
        gameManager.Score+= 10;
      }
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
