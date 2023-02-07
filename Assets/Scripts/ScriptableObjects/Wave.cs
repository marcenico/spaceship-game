using UnityEngine;
using System.Collections.Generic;
using PathCreation;

[System.Serializable]
public class Enemy {
  public EnemyBehaviour prefab = null;
  public PathCreator path = null;
}


[CreateAssetMenu(fileName = "NewWave", menuName = "Wave/Wave Config", order = 0)]
public class Wave : ScriptableObject {
  public List<Enemy> enemies = new List<Enemy>();
  public float initialWaitTime = 1f;
  public float minCadenceTime = 1f;
  public float maxCadenceTime = 2f;
  public int amountToSpawn = 10;
}
