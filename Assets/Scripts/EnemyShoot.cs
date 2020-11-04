using UnityEngine;

public class EnemyShoot : MonoBehaviour, IShootable {
  public GameObject projectile;
  public float nextFire = 1f;
  private float currentTime = 0f;
  private Transform projectileSpawn;

  void Start() {
    projectileSpawn = this.gameObject.transform;
  }

  void Update() {
    Shoot();
  }

  public void Shoot() {
    currentTime += Time.deltaTime;
    if (currentTime > nextFire) {
      Instantiate(projectile, projectileSpawn.position, Quaternion.identity);
      currentTime = 0f;
    }
  }
}