using UnityEngine;

[RequireComponent(typeof(OnTriggerDo))]
public class ProjectileBehaviour : MonoBehaviour, IMovable {
  [SerializeField] public Projectile config = null;
  [SerializeField] private bool followPlayer = false;
  private OnTriggerDo triggerDo = null;
  private Vector3 targetPosition = Vector3.zero;
  private Vector3 moveDirection = Vector3.zero;

  private void Awake() {
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void OnEnable() {
    if (!followPlayer) return;
    GetTargetPosition();
    SetShotTrajectory();
    FaceTarget();
  }


  private void Update() {
    DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  private void GetTargetPosition() {
    targetPosition = (Vector3)FindObjectOfType<PlayerBehaviour>()?.transform.position;
  }

  private void SetShotTrajectory() {
    moveDirection = (targetPosition - transform.position).normalized;
  }

  private void FaceTarget() {
    float angleRad = Mathf.Atan2(targetPosition.y - transform.position.y, targetPosition.x - transform.position.x);
    float angleDeg = (180 / Mathf.PI) * angleRad - 90;
    transform.rotation = Quaternion.Euler(0, 0, angleDeg);
  }

  public void MakeDamage() {
    if (triggerDo.otherCollider.tag == "Wall") return;

    switch (gameObject.layer) {
      case 11: // Proyectil enemigo
        InputProvider.TriggerOnHasDamage(config.damage);
        break;
      case 8: // Proyectil player
        triggerDo.statsTarget.TakeLife(config.damage);
        break;
      default: break;
    }
  }

  public void DoMovement() {
    if (followPlayer) {
      transform.position += moveDirection * Time.deltaTime * config.speed * 5f;
      return;
    }
    transform.position += transform.up * Time.deltaTime * config.speed * 5f;
  }

  public void DoMovement(Vector3 direction) {
    throw new System.NotImplementedException();
  }
}