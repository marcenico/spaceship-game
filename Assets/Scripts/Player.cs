using UnityEngine;

public class Player : MonoBehaviour {
  public float moveSpeed = 10.0f;
  public Rigidbody2D player;

  void Start() {
    player = this.GetComponent<Rigidbody2D>();
  }

  void FixedUpdate() {
    MovePlayer();
  }

  public void MovePlayer() {
    player.velocity = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * moveSpeed;
  }
}