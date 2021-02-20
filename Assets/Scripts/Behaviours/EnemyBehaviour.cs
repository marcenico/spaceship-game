using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(ShootController))]
public class EnemyBehaviour : MonoBehaviour {
  private MovementController movementController = null;
  private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
    shootController = GetComponent<ShootController>();
  }

  private void Update() {
    movementController.DoMovement();
    StartCoroutine(shootController.Shoot());
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}