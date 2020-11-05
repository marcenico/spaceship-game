using UnityEngine;

[System.Serializable]
public class Boundary {
  public float xMinimum, xMaximum, yMinimum, yMaximum;
}
public class PlayerController : MonoBehaviour {
  public GameObject projectile;
  public Transform[] spawnProjectilesPoints;
  public MovementController movementController;
  public Boundary boundary;

  private void Start() {
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
  }

  private void OnHasMove(Vector3 direction) {
    movementController.DoMovement(direction);
  }

  private void OnHasShoot() {
    foreach (var spawnPoint in spawnProjectilesPoints) {
      Instantiate(projectile, spawnPoint.position, Quaternion.identity);
    }
  }

  private void Update() {
    float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
    float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
    transform.position = new Vector3(x, y);
  }
}