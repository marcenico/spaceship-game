using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ProjectileBehaviour : MonoBehaviour {
  private MovementController movementController;

  void Start() {
    movementController = GetComponent<MovementController>();
  }

  void Update() {
    movementController.DoMovement();
  }
}