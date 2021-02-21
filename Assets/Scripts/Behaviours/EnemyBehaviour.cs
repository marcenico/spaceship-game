using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class EnemyBehaviour : MonoBehaviour {
  [HideInInspector] public EnemyConfig enemyConfig = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private MovementController movementController = null;


  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void Start() {
    SetConfig();
  }

  private void Update() {
    movementController.DoMovement();
    if (shootController) StartCoroutine(shootController.Shoot());
  }

  private void SetConfig() {
    if (movementController) movementController.speed = enemyConfig.speed;
    spriteRenderer.sprite = enemyConfig.sprite;
  }

  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}