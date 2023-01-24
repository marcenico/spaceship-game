using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour {
  public float speed = 10f;
  [HideInInspector] public Vector3 direction;
  [HideInInspector] public Rigidbody2D rigidBody = null;

  private void Awake() {
    rigidBody = GetComponent<Rigidbody2D>();
  }

  public void DoMovement() {
    rigidBody.velocity = direction * speed * Time.fixedDeltaTime * 100;
  }

  public void SetConfig(Character config) {
    speed = config.speed;
  }
}