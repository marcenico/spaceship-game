using UnityEngine;
using System.Collections;

public class SpawnController : MonoBehaviour {
  [SerializeField] private GameObject prefab = null;
  [SerializeField] private Vector3 spawnPosition = Vector3.zero;
  [SerializeField] private float initialWaitTime = 1f;
  [SerializeField] private float spawnCadence = 1f;
  [SerializeField] private int amountToSpawn = 10;

  private void Start() {
    StartCoroutine(SpawnCoroutine());
  }

  private IEnumerator SpawnCoroutine() {
    yield return new WaitForSeconds(initialWaitTime);
    for (int i = 0; i < amountToSpawn; i++) {
      Vector3 randomPosition = new Vector3(Random.Range(-spawnPosition.x, spawnPosition.x), spawnPosition.y, spawnPosition.z);
      Spawn(randomPosition);
      yield return new WaitForSeconds(spawnCadence);
    }
  }

  private void Spawn(Vector3 position) {
    GameObject go = PoolController.Instance.GetOne(prefab.name);
    go.transform.position = position;
    go.SetActive(true);
  }
}