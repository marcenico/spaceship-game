using UnityEngine;

public class MovementController : MonoBehaviour {
  public float speed = 10f;

  public void DoMovement(Vector3 movementValue) {
    transform.Translate(movementValue * speed * Time.deltaTime);
  }
}