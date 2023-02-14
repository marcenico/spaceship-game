using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveBehaviour : MonoBehaviour {
  [SerializeField] private List<Wave> waves = new List<Wave>();
  private int startNextWave;

  private void Start() {
    StartCoroutine(SpawnCoroutine());
  }

  private void OnDisable() {
    StopAllCoroutines();
  }

  private void OnDestroy() {
    StopAllCoroutines();
  }

  private IEnumerator SpawnCoroutine() {
    foreach (var wave in waves) {
      GameManager.Instance.StartNextWaveCounter(wave.items[0].initialWaitTime);
      foreach (var item in wave.items) {

        yield return new WaitForSeconds(item.initialWaitTime);

        for (int i = 0; i < item.amountToSpawn; i++) {
          Spawn(item);
          yield return new WaitForSeconds(Random.Range(item.minCadenceTime, item.maxCadenceTime));
        }
      }
    }
  }

  private void Spawn(Item item) {
    GameObject go = PoolController.Instance.GetOne(item.prefab);
    go.SetActive(true);
  }
}
