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

  private void OnEnable() {
    SetConfig();
  }

  private void FixedUpdate() {
    if (movementController) movementController.DoMovement();
  }

  private void Update() {
    if (shootController) StartCoroutine(shootController.Shoot());
  }

  public void GiveExperience() {
    GameManager.Instance.AddExperience(character.experienceOnDead);
  }

  private void SetConfig() {
    if (movementController) movementController.SetSpeed(character.speed);
    if (movementController) movementController.SetDirection(new Vector3(0, -1, 0));
    if (statsController) statsController.SetConfig(character);
    if (shootController) shootController.SetConfig(character);
    spriteRenderer.sprite = character.skin;
  }


  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }


}