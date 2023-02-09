using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveBehaviour : MonoBehaviour {
  [SerializeField] private List<Wave> waves = new List<Wave>();

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
      foreach (var item in wave.items) {
        yield return new WaitForSeconds(item.initialWaitTime);

        GameManager.Instance.AddWaveNumber();

        for (int i = 0; i < item.amountToSpawn; i++) {
          Spawn(item);
          yield return new WaitForSeconds(Random.Range(item.minCadenceTime, item.maxCadenceTime));
        }
      }
    }
    Debug.Log("Finish Wave!");
  }

  private void Spawn(Item item) {
    GameObject go = PoolController.Instance.GetOne(item.prefab.name);
    go.SetActive(true);
  }
}
