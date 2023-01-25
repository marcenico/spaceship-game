using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
  private float speed = 1f;
  [HideInInspector] public Vector3 direction = new Vector3(0, -2, 0);
  [HideInInspector] public Rigidbody2D rigidBody = null;

  private void Awake() {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  public void DoMovement() {
    if (rigidBody is null) return;
    rigidBody.velocity = direction * speed * Time.fixedDeltaTime * 100;
  }

  public void SetDirection(Vector3 newDirection) {
    direction = newDirection;
  }

  public void SetSpeed(float newSpeed) {
    speed = newSpeed;
  }
}