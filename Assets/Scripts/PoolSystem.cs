using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Pool {
  public string name = "";
  public List<GameObject> gameObjects = new List<GameObject>();
}

public class PoolSystem : MonoBehaviour {
  public static PoolSystem Instance;
  public List<GameObject> prefabs = new List<GameObject>();
  public List<Pool> pools = new List<Pool>();
  private int initialValue = 6;

  private void Awake() {
    if (Instance != null) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    FillPool();
  }

  private void FillPool() {
    for (int i = 0; i < prefabs.Count; i++) {
      Pool pool = new Pool();
      for (int j = 0; j < initialValue; j++) {
        GameObject go = Instantiate(prefabs[i], Vector3.zero, Quaternion.identity);
        go.SetActive(false);
        pool.gameObjects.Add(go);
        pool.name = go.name;
      }
      pools.Add(pool);
    }
  }

  public GameObject GetOne(string prefabName) {
    GameObject go = null;
    for (int i = 0; i < pools.Count; i++) {
      if (pools[i].name.Contains(prefabName)) {
        if (pools[i].gameObjects.Count > 0) {
          go = pools[i].gameObjects[pools[i].gameObjects.Count - 1];
          pools[i].gameObjects.RemoveAt(pools[i].gameObjects.Count - 1);
          go.SetActive(true);
          return go;
        } else {
          return InstanciateOne(prefabName);
        }
      }
    }
    return go;
  }

  private GameObject InstanciateOne(string prefabName) {
    GameObject go = null;
    for (int i = 0; i < pools.Count; i++) {
      if (pools[i].name.Contains(prefabName)) {
        go = Instantiate(prefabs[i], Vector3.zero, Quaternion.identity);
        go.SetActive(false);
        pools[i].gameObjects.Add(go);
      }
    }
    return go;
  }

  public void ReturnOneToPool(GameObject go) {
    for (int i = 0; i < pools.Count; i++) {
      if (pools[i].name.Contains(go.name)) {
        pools[i].gameObjects.Add(go);
        return;
      }
    }
  }
}