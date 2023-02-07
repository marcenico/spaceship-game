using UnityEngine;
using System.Collections.Generic;

// [System.Serializable]
// public class Enemy {
//   public GameObject prefab;
//   public int cost;
// }

public class WaveManager2 : MonoBehaviour {
  // public List<Enemy> enemies = new List<Enemy>();
  // public int currentWave;
  // public List<GameObject> enemiesToSpawn = new List<GameObject>();
  // public Transform[] spawnLocation;
  // public int spawnIndex;

  // public int waveDuration;
  // private int waveValue;
  // private float waveTimer;
  // private float spawnInterval;
  // private float spawnTimer;

  // public List<GameObject> spawnedEnemies = new List<GameObject>();

  // private Vector3 positionToSpawn = Vector3.zero;

  // void Start() {
  //   GenerateWave();
  //   SetPositionToSpawn();
  // }

  // // Update is called once per frame
  // void FixedUpdate() {
  //   if (spawnTimer <= 0) {
  //     //spawn an enemy
  //     if (enemiesToSpawn.Count > 0) {
  //       GameObject enemy = (GameObject)Instantiate(enemiesToSpawn[0], positionToSpawn, Quaternion.identity); // spawn first enemy in our list
  //       enemiesToSpawn.RemoveAt(0); // and remove it
  //       spawnedEnemies.Add(enemy);
  //       spawnTimer = spawnInterval;

  //       if (spawnIndex + 1 <= spawnLocation.Length - 1) {
  //         spawnIndex++;
  //       } else {
  //         spawnIndex = 0;
  //       }
  //     } else {
  //       waveTimer = 0; // if no enemies remain, end wave
  //     }
  //   } else {
  //     spawnTimer -= Time.fixedDeltaTime;
  //     waveTimer -= Time.fixedDeltaTime;
  //   }

  //   if (waveTimer <= 0 && spawnedEnemies.Count <= 0) {
  //     currentWave++;
  //     GenerateWave();
  //   }
  // }

  // public void GenerateWave() {
  //   waveValue = currentWave * 10;
  //   GenerateEnemies();

  //   spawnInterval = waveDuration / enemiesToSpawn.Count; // gives a fixed time between each enemies
  //   waveTimer = waveDuration; // wave duration is read only
  // }

  // public void GenerateEnemies() {
  //   List<GameObject> generatedEnemies = new List<GameObject>();
  //   while (waveValue > 0 || generatedEnemies.Count < 50) {
  //     int randEnemyId = UnityEngine.Random.Range(0, enemies.Count);
  //     int randEnemyCost = enemies[randEnemyId].cost;

  //     if (waveValue - randEnemyCost >= 0) {
  //       generatedEnemies.Add(enemies[randEnemyId].prefab);
  //       waveValue -= randEnemyCost;
  //     } else if (waveValue <= 0) {
  //       break;
  //     }
  //   }
  //   enemiesToSpawn.Clear();
  //   enemiesToSpawn = generatedEnemies;
  // }

  // private void SetPositionToSpawn() {
  //   float positionY = BoundaryBehaviour.Instance.boundaries.top * 1.5f;
  //   positionToSpawn = new Vector3(0, positionY, 0);
  // }
}