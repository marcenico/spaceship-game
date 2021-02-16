using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Pool {
  public int initialSizeValue = 12;
  public GameObject prefab = null;
  [HideInInspector] public List<GameObject> gameObjects = new List<GameObject>();
}

public class PoolController : MonoBehaviour {
  public static PoolController Instance;
  public List<Pool> pools = new List<Pool>();

  private void Awake() {
    if (Instance != null) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    FillPools();
  }

  private void FillPools() {
    foreach (Pool pool in pools) {
      for (int i = 0; i < pool.initialSizeValue; i++) {
        GameObject go = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
        go.name = pool.prefab.name;
        go.SetActive(false);
        pool.gameObjects.Add(go);
      }
    }
  }

  public GameObject GetOne(string prefabName) {
    GameObject go = null;
    Pool pool = pools.Find(x => x.prefab.name == prefabName);
    if (pool.gameObjects.Count > 0) {
      go = pool.gameObjects[pool.gameObjects.Count - 1];
      pool.gameObjects.RemoveAt(pool.gameObjects.Count - 1);
      return go;
    } else {
      go = Instantiate(pool.prefab, Vector3.zero, Quaternion.identity);
      go.name = pool.prefab.name;
      pool.gameObjects.Add(go);
      return go;
    }
  }

  public void ReturnOneToPool(GameObject go) {
    Pool pool = pools.Find(x => x.prefab.name == go.name);
    pool.gameObjects.Add(go);
  }
}