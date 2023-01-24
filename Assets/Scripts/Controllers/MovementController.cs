using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
  private float speed = 10f;
  [HideInInspector] public Vector3 direction;
  [HideInInspector] public Rigidbody2D rigidBody = null;

  private void Awake() {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  public void DoMovement() {
    if (rigidBody is null) return;
    rigidBody.velocity = direction * speed * Time.fixedDeltaTime * 100;
  }

  public void SetSpeed(float newSpeed) {
    speed = newSpeed;
  }
}