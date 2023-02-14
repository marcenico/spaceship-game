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
  private Vector3 positionToSpawn = Vector3.zero;

  private void Awake() {
    if (Instance != null) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    SetPositionToSpawn();
    FillPools();
  }

  private void SetPositionToSpawn() {
    float positionY = BoundaryBehaviour.Instance.OnGetBoundaries().top * 1.5f;
    positionToSpawn = new Vector3(0, positionY, 0);
  }

  private void FillPools() {
    foreach (Pool pool in pools) {
      for (int i = 0; i < pool.initialSizeValue; i++) {
        if (!pool.prefab) continue;
        GameObject go = Instantiate(pool.prefab, positionToSpawn, pool.prefab.transform.rotation);
        go.name = pool.prefab.name;
        go.SetActive(false);
        pool.gameObjects.Add(go);
      }
    }
  }

  public void ReturnOneToPool(GameObject go) {
    go.transform.position = positionToSpawn;
    Pool pool = pools.Find(x => x.prefab.name == go.name);
    pool.gameObjects.Add(go);
  }

  public GameObject GetOne(GameObject prefab) {
    Pool pool = pools.Find(x => x.prefab.name == prefab.name);


    if (pool is null) {
      pool = AddPool(prefab);
    }

    List<GameObject> onlyInactives = pool.gameObjects.FindAll(x => x.activeSelf == false);
    GameObject go = null;

    if (onlyInactives.Count > 0) {
      go = onlyInactives[onlyInactives.Count - 1];
      onlyInactives.RemoveAt(onlyInactives.Count - 1);
      return go;
    } else {
      go = Instantiate(pool.prefab, positionToSpawn, pool.prefab.transform.rotation);
      go.name = pool.prefab.name;
      onlyInactives.Add(go);
      return go;
    }
  }

  private Pool AddPool(GameObject prefab) {
    Debug.Log(prefab);

    Pool pool = new Pool();
    pool.initialSizeValue = 10;
    pool.prefab = prefab;

    for (var i = 0; i < pool.initialSizeValue; i++) {
      pool.gameObjects.Add(prefab);
    }

    pools.Add(pool);

    return pool;
  }
}