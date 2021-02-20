using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyBehaviour : MonoBehaviour {
  private MovementController movementController = null;
  [SerializeField] private ShootController shootController = null;

  private void Start() {
    movementController = GetComponent<MovementController>();
  }

  private void Update() {
    movementController.DoMovement();
    if (shootController) StartCoroutine(shootController.Shoot());
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}