using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Item {
  public GameObject prefab = null;
  public float initialWaitTime = 1f;
  public float minCadenceTime = 1f;
  public float maxCadenceTime = 2f;
  public int amountToSpawn = 10;
}


[CreateAssetMenu(fileName = "NewWave", menuName = "Wave/Wave Config", order = 0)]
public class Wave : ScriptableObject {
  public List<Item> items = new List<Item>();
}
