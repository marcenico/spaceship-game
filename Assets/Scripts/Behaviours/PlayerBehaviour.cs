using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(ShootController))]
public class PlayerBehaviour : MonoBehaviour {
  private MovementController movementController = null;
  private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
    shootController = GetComponent<ShootController>();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
  }

  private void OnHasMove(Vector3 direction) {
    Assert.IsNotNull(movementController, message: $"No debe ser nulo {movementController}");
    transform.position = BoundaryBehaviour.Instance.GetClampPosition(transform.position);
    movementController.direction = direction;
    movementController.DoMovement();
  }

  private void OnHasShoot() {
    Assert.IsNotNull(shootController, message: $"No debe ser nulo {shootController}");
    StartCoroutine(shootController.Shoot());
  }

  private void OnDestroy() {
    InputProvider.OnHasMove -= OnHasMove;
    InputProvider.OnHasShoot -= OnHasShoot;
  }
}