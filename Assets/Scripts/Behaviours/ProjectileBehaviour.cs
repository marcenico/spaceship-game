using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ProjectileBehaviour : MonoBehaviour {
  private MovementController movementController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.DoMovement();
  }

  private void OnDisable() {
    PoolSystem.Instance.ReturnOneToPool(gameObject);
  }
}