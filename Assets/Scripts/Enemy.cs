  using UnityEngine;

  public class Enemy : MonoBehaviour {
    public float moveSpeed = 15.0f;
    private bool changeDirection = false;
    private Rigidbody2D enemy;

    void Start() {
      enemy = this.gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
      moveEnemy();
    }

    public void moveEnemy() {
      enemy.velocity = changeDirection ? new Vector2(1, 0) * -1 * moveSpeed : new Vector2(1, 0) * moveSpeed;
    }

    void OnCollisionEnter2D(Collision2D col) {
      changeDirection = col.gameObject.name == "WallRight" ? true : false;
    }
  }