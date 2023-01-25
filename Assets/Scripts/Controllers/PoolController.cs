using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Pool {
  public int initialSizeValue = 12;
  public GameObject prefab = null;
  public List<GameObject> gameObjects = new List<GameObject>();
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
        if (!pool.prefab) continue;
        GameObject go = Instantiate(pool.prefab, Vector3.zero, pool.prefab.transform.rotation);
        go.name = pool.prefab.name;
        go.SetActive(false);
        pool.gameObjects.Add(go);
      }
    }
  }

  public void ReturnOneToPool(GameObject go) {
    Pool pool = pools.Find(x => x.prefab.name == go.name);
    pool.gameObjects.Add(go);
  }

  public GameObject GetOne(string prefabName) {
    GameObject go = null;
    Pool pool = pools.Find(x => x.prefab.name == prefabName);

    List<GameObject> onlyInactives = pool.gameObjects.FindAll(x => x.activeSelf == false);

    if (onlyInactives.Count > 0) {
      go = onlyInactives[onlyInactives.Count - 1];
      onlyInactives.RemoveAt(onlyInactives.Count - 1);
      return go;
    } else {
      go = Instantiate(pool.prefab, Vector3.zero, pool.prefab.transform.rotation);
      go.name = pool.prefab.name;
      onlyInactives.Add(go);
      return go;
    }
  }
}