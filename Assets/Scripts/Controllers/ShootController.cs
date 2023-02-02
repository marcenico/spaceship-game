using UnityEngine;
using System.Collections;

[System.Serializable]
public class Shoot {
  [HideInInspector] public bool canFire = true;
  public GameObject prefab = null;
  public float nextFire = 1f;
  public Transform[] spawnProjectilesPoints = null;
}

public class ShootController : MonoBehaviour, IShootable {
  [SerializeField] private Shoot normalShoot = null;
  [SerializeField] private Shoot shootSpecial = null;
  private float waitFirstShoot = 0f;
  private bool isFirstShoot = true;

  public void SetConfig(Character config) {
    normalShoot.prefab = config.shootPrefab;
    normalShoot.nextFire = config.nextFire;
    shootSpecial.prefab = config.shootSpecialPrefab;
    shootSpecial.nextFire = config.nextFireSpecial;
    waitFirstShoot = config.waitFirstShoot;
    isFirstShoot = true;
  }

  public IEnumerator Shoot() {
    if (!normalShoot.canFire) yield break;

    if (PoolController.Instance == null) {
      Debug.LogWarning("No hay instancia de PoolController");
      yield break;
    }

    if (isFirstShoot) {
      yield return new WaitForSeconds(waitFirstShoot);
      isFirstShoot = false;
    } else {
      foreach (var spawnPoint in normalShoot.spawnProjectilesPoints) {
        GameObject go = PoolController.Instance.GetOne(normalShoot.prefab.name);
        go.transform.position = spawnPoint.position;
        go.transform.rotation = transform.rotation;
        go.SetActive(true);
      }
      normalShoot.canFire = false;
      yield return new WaitForSeconds(normalShoot.nextFire);
      normalShoot.canFire = true;
    }
  }

  public IEnumerator ShootSpecial() {
    if (!shootSpecial.canFire) yield break;
    foreach (var spawnPoint in shootSpecial.spawnProjectilesPoints) {
      GameObject go = PoolController.Instance.GetOne(shootSpecial.prefab.name);
      go.transform.position = spawnPoint.position;
      go.transform.rotation = transform.rotation;
      go.SetActive(true);
    }
    shootSpecial.canFire = false;
    yield return new WaitForSeconds(shootSpecial.nextFire);
    shootSpecial.canFire = true;
  }

  private void OnDisable() {
    normalShoot.canFire = true;
  }
}