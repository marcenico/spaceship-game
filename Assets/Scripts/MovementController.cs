using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
  public float speed = 10f;
  [HideInInspector] public Rigidbody2D rigidBody = null;

  private void Start() {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  public void DoMovement(Vector3 movementValue) {
    rigidBody.velocity = movementValue * speed * Time.fixedDeltaTime * 100;
  }
}