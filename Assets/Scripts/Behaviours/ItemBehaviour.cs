using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ItemBehaviour : MonoBehaviour {
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void FixedUpdate() {
    movementController.DoMovement();
  }
}
