using UnityEngine;

[System.Serializable]
public class Boundary {
  public float xMinimum, xMaximum, yMinimum, yMaximum;
}

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(ShootController))]
public class PlayerController : MonoBehaviour {
  public Boundary boundary;
  private MovementController movementController = null;
  private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
    shootController = GetComponent<ShootController>();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
  }

  private void OnHasMove(Vector3 direction) {
    movementController.direction = direction;
    movementController.DoMovement();
  }

  private void OnHasShoot() {
    StartCoroutine(shootController.Shoot());
  }

  private void Update() {
    float x = Mathf.Clamp(transform.position.x, boundary.xMinimum, boundary.xMaximum);
    float y = Mathf.Clamp(transform.position.y, boundary.yMinimum, boundary.yMaximum);
    transform.position = new Vector3(x, y);
  }
}