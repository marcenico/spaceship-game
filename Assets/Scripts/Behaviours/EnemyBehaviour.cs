using UnityEngine;

[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(MovementController))]
public class EnemyBehaviour : MonoBehaviour {
  [SerializeField] public Character character = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private StatsController statsController = null;
  private MovementController movementController = null;


  private void Awake() {
    statsController = GetComponent<StatsController>();
    movementController = GetComponent<MovementController>();
  }

  private void Start() {
    SetConfig();
  }

  private void Update() {
    movementController.DoMovement();
    if (shootController) StartCoroutine(shootController.Shoot());
  }

  public void GiveExperience() {
    GameManager.Instance.AddExperience(character.experienceOnDead);
  }

  private void SetConfig() {
    if (movementController) movementController.SetConfig(character);
    if (statsController) statsController.SetConfig(character);
    if (shootController) shootController.SetConfig(character);
    spriteRenderer.sprite = character.skin;
  }


  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  private void OnEnable() {
    SetConfig();
  }
}