using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyBehaviour : MonoBehaviour {
  private MovementController movementController;

  private void Start() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.DoMovement();
  }
}