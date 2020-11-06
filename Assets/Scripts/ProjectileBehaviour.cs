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

  void OnTriggerEnter2D(Collider2D colider) {
    switch (colider.gameObject.tag) {
      case "Player":
        colider.gameObject.SetActive(false);
        Destroy(this.gameObject);
        break;
      case "Enemy":
        colider.gameObject.SetActive(false);
        Destroy(this.gameObject);
        break;
      case "Wall":
        Destroy(this.gameObject);
        break;
    }
  }
}