using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(ShootController))]
public class PlayerController : MonoBehaviour {
  private MovementController movementController = null;
  private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
    shootController = GetComponent<ShootController>();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
  }

  private void OnHasMove(Vector3 direction) {
    if (!movementController) return;
    movementController.direction = direction;
    movementController.DoMovement();
    SetPlayerBoudaries();
  }

  private void OnHasShoot() {
    if (!shootController) return;
    StartCoroutine(shootController.Shoot());
  }

  private void SetPlayerBoudaries() {
    BoundaryController boundary = GameManager.Instance.boundaryController;
    float x = Mathf.Clamp(transform.position.x, boundary.left, boundary.right);
    float y = Mathf.Clamp(transform.position.y, boundary.bottom, boundary.top);
    transform.position = new Vector3(x, y);
  }
}