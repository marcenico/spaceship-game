using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ProjectileBehaviour : MonoBehaviour {
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}