using UnityEngine;

[RequireComponent(typeof(MovementController))]
[RequireComponent(typeof(OnTriggerDo))]
public class ProjectileBehaviour : MonoBehaviour {
  [SerializeField] public Projectile config = null;
  private MovementController movementController = null;
  private OnTriggerDo triggerDo = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void Update() {
    movementController.DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  public void MakeDamage() {
    triggerDo.statsTarget.TakeLife(config.damage);
  }
}