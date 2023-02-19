using UnityEngine;

[RequireComponent(typeof(OnTriggerDo))]
public class ProjectileBehaviour : MonoBehaviour, IMovable {
  [SerializeField] public Projectile config = null;
  [SerializeField] private bool followPlayer = false;
  private OnTriggerDo triggerDo = null;
  private Vector3 directionToTravel;


  private void Awake() {
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void OnEnable() {
    if (!followPlayer) return;
    directionToTravel = (Vector3)FindObjectOfType<PlayerBehaviour>()?.transform.position;
    directionToTravel.Normalize();
  }


  private void Update() {
    DoMovement();
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
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
      transform.position += directionToTravel * Time.deltaTime * config.speed * 5f;
      return;
    }

    transform.position += transform.up * Time.deltaTime * config.speed * 5f;
  }

  public void DoMovement(Vector3 direction) {
    throw new System.NotImplementedException();
  }
}