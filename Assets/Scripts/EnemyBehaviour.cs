using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyBehaviour : MonoBehaviour {
  private bool changeDirection = false;
  private MovementController movementController;

  private void Start() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.direction = changeDirection ? new Vector3(-1, 0, 0) : new Vector3(1, 0, 0);
    movementController.DoMovement();
  }

  private void OnTriggerEnter2D(Collider2D collider) {
    changeDirection = collider.gameObject.name == "WallRight" ? true : false;

  }
}