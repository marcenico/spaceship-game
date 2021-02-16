using UnityEngine;
using System.Collections;

public class ShootController : MonoBehaviour, IShootable {
  public Transform[] spawnProjectilesPoints;
  [SerializeField] private GameObject projectile = null;
  [SerializeField] private float nextFire = 1f;
  private bool canFire = true;

  public IEnumerator Shoot() {
    if (!canFire) yield break;
    foreach (var spawnPoint in spawnProjectilesPoints) {
      PoolSystem.Instance.GetOne(projectile.name).transform.position = spawnPoint.position;
    }
    canFire = false;
    yield return new WaitForSeconds(nextFire);
    canFire = true;
  }
}