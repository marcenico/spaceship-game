using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour, IShootable {
  public Transform[] spawnProjectilesPoints;
  [SerializeField] private GameObject prefab = null;
  [SerializeField] private float nextFire = 1f;
  private bool canFire = true;

  public IEnumerator Shoot() {
    if (!canFire) yield break;
    foreach (var spawnPoint in spawnProjectilesPoints) {
      GameObject poolPrefab = PoolSystem.Instance.GetOne(prefab.name);
      poolPrefab.transform.position = spawnPoint.position;
      poolPrefab.SetActive(true);
    }
    canFire = false;
    yield return new WaitForSeconds(nextFire);
    canFire = true;
  }
}