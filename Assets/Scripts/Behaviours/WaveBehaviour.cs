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
      yield return new WaitForSeconds(wave.initialWaitTime);
      for (int i = 0; i < wave.amountToSpawn; i++) {
        Spawn(wave.enemies[Random.Range(0, wave.enemies.Count)]);
        yield return new WaitForSeconds(Random.Range(wave.minCadenceTime, wave.maxCadenceTime));
      }
    }
    Debug.Log("Finish Wave!");
  }

  private void Spawn(Enemy enemy) {
    GameObject go = PoolController.Instance.GetOne(enemy.prefab.name);
    go.SetActive(true);
  }
}