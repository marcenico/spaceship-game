using UnityEngine;

public class MoveProjectile : MonoBehaviour {
  public float moveSpeed = 10.0f;
  public bool isPlayerTarget = false;
  private Rigidbody2D projectile;

  void Start() {
    projectile = GetComponent<Rigidbody2D>();
  }

  void Update() {
    projectile.velocity = new Vector2(0, isPlayerTarget ? -1 : 1) * moveSpeed;
  }

  void OnCollisionEnter2D(Collision2D collision) {
    switch (collision.gameObject.tag) {
      case "Player":
        collision.gameObject.SetActive(false);
        Destroy(this.gameObject);
        break;
      case "Enemy":
        collision.gameObject.SetActive(false);
        Destroy(this.gameObject);
        break;
      case "Wall":
        Destroy(this.gameObject);
        break;
    }
  }
}