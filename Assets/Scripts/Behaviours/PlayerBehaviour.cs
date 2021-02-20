using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(MovementController))]
public class PlayerBehaviour : MonoBehaviour {
  private MovementController movementController = null;
  [SerializeField] private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
    InputProvider.OnHasShootFirstHability += OnHasShootFirstHability;
  }

  private void OnHasMove(Vector3 direction) {
    Assert.IsNotNull(movementController, message: $"No debe ser nulo {movementController}");
    transform.position = BoundaryBehaviour.Instance.GetClampPosition(transform.position);
    movementController.direction = direction;
    movementController.DoMovement();
  }

  private void OnHasShoot() {
    if (!shootController) return;
    StartCoroutine(shootController.Shoot());
  }

  private void OnHasShootFirstHability() {
    if (!shootController) return;
    StartCoroutine(shootController.ShootFirstAbility());
  }

  private void OnDestroy() {
    UnsuscribeEvents();
  }

  private void OnDisable() {
    UnsuscribeEvents();
  }

  private void UnsuscribeEvents() {
    InputProvider.OnHasMove -= OnHasMove;
    InputProvider.OnHasShoot -= OnHasShoot;
    InputProvider.OnHasShoot -= OnHasShoot;
  }
}