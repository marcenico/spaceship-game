using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shoot {
  [HideInInspector] public bool canFire = true;
  [ReadOnly] public GameObject prefab = null;
  [ReadOnly] public float nextFire = 1f;
  public Transform[] spawnProjectilesPoints = null;
}

public class ShootController : MonoBehaviour, IShootable {
  [SerializeField] private Shoot normalShoot = null;
  [SerializeField] private Shoot firstAbilityShoot = null;

  public void SetConfig(PlayerConfig config) {
    normalShoot.prefab = config.shootPrefab;
    normalShoot.nextFire = config.nextFire;
  }

  public IEnumerator Shoot() {
    if (!normalShoot.canFire) yield break;

    if (PoolController.Instance == null) {
      Debug.LogWarning("No hay instancia de PoolController");
      yield break;
    }

    foreach (var spawnPoint in normalShoot.spawnProjectilesPoints) {
      GameObject go = PoolController.Instance.GetOne(normalShoot.prefab.name);
      go.transform.position = spawnPoint.position;
      go.SetActive(true);
    }
    normalShoot.canFire = false;
    yield return new WaitForSeconds(normalShoot.nextFire);
    normalShoot.canFire = true;
  }

  public IEnumerator ShootFirstAbility() {
    if (!firstAbilityShoot.canFire) yield break;
    foreach (var spawnPoint in firstAbilityShoot.spawnProjectilesPoints) {
      GameObject go = PoolController.Instance.GetOne(firstAbilityShoot.prefab.name);
      go.transform.position = spawnPoint.position;
      go.SetActive(true);
    }
    firstAbilityShoot.canFire = false;
    yield return new WaitForSeconds(firstAbilityShoot.nextFire);
    firstAbilityShoot.canFire = true;
  }
}