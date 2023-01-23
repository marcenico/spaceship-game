using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ProjectileBehaviour : MonoBehaviour {
  [SerializeField] public Projectile config = null;
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}