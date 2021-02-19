using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shoot {
  [HideInInspector] public bool canFire = true;
  public Transform[] spawnProjectilesPoints = null;
  public GameObject prefab = null;
  public float nextFire = 1f;
}

public class ShootController : MonoBehaviour, IShootable {
  [SerializeField] private Shoot normalShoot = null;
  [SerializeField] private Shoot firstAbilityShoot = null;

  public IEnumerator Shoot() {
    if (!normalShoot.canFire) yield break;
    foreach (var spawnPoint in normalShoot.spawnProjectilesPoints) {
      GameObject poolPrefab = PoolController.Instance.GetOne(normalShoot.prefab.name);
      poolPrefab.transform.position = spawnPoint.position;
      poolPrefab.SetActive(true);
    }
    normalShoot.canFire = false;
    yield return new WaitForSeconds(normalShoot.nextFire);
    normalShoot.canFire = true;
  }

  public IEnumerator ShootFirstAbility() {
    if (!firstAbilityShoot.canFire) yield break;
    foreach (var spawnPoint in firstAbilityShoot.spawnProjectilesPoints) {
      GameObject poolPrefab = PoolController.Instance.GetOne(firstAbilityShoot.prefab.name);
      poolPrefab.transform.position = spawnPoint.position;
      poolPrefab.SetActive(true);
    }
    firstAbilityShoot.canFire = false;
    yield return new WaitForSeconds(firstAbilityShoot.nextFire);
    firstAbilityShoot.canFire = true;
  }
}