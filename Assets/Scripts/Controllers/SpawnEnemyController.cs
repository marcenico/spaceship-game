using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnEnemyController : MonoBehaviour {
  [SerializeField] private List<GameObject> enemies = new List<GameObject>();
  [SerializeField] private float initialWaitTime = 1f;
  [SerializeField] private float spawnCadence = 1f;
  [SerializeField] private int amountToSpawn = 10;
  private Vector3 positionToSpawn = Vector3.zero;

  private void Start() {
    StartCoroutine(SpawnCoroutine());
  }

  private IEnumerator SpawnCoroutine() {

    yield return new WaitForSeconds(initialWaitTime);
    SetPositionToSpawn();
    for (int i = 0; i < amountToSpawn; i++) {
      Spawn(enemies[Random.Range(0, enemies.Count)], positionToSpawn);
      yield return new WaitForSeconds(spawnCadence);
    }
  }

  private void SetPositionToSpawn() {
    float positionY = BoundaryBehaviour.Instance.boundaries.top * 1.5f;
    positionToSpawn = new Vector3(0, positionY, 0);
  }

  private void Spawn(GameObject prefab, Vector3 position) {
    GameObject go = PoolController.Instance.GetOne(prefab.name);
    go.transform.position = position;
    go.SetActive(true);
  }
}