using UnityEngine;

[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(OnTriggerDo))]
public class PlayerBehaviour : MonoBehaviour, IMovable {
  [SerializeField] private Character character = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private StatsController statsController = null;
  private Rigidbody2D rigidBody2D = null;
  private OnTriggerDo triggerDo = null;

  private void Awake() {
    statsController = GetComponent<StatsController>();
    rigidBody2D = GetComponent<Rigidbody2D>();
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void Start() {
    SetConfig();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
    InputProvider.OnHasShootSpecial += OnHasShootSpecial;
    InputProvider.OnHasDamage += OnHasDamage;
    InputProvider.OnHasLevelUp += OnHasLevelUp;
  }

  public void OnDefeat() {
    GameManager.Instance.isPlayerDead = true;
  }

  public void MakeDamage() {
    if (triggerDo.otherCollider.tag != "Enemy") return;
    triggerDo.statsTarget.TakeLife(character.damageOnTrigger);
  }

  private void SetConfig() {
    if (statsController) statsController.SetConfig(character);
    if (shootController) shootController.SetConfig(character);
    spriteRenderer.sprite = character.skin;
  }

  private void OnHasMove(Vector3 direction) {
    DoMovement(direction);
  }

  private void OnHasShoot() {
    if (!shootController || !character.shootPrefab) return;
    StartCoroutine(shootController.Shoot());
  }

  private void OnHasShootSpecial() {
    if (!shootController || !character.shootSpecialPrefab) return;
    StartCoroutine(shootController.ShootSpecial());
  }

  private void OnHasDamage(float damage) {
    statsController.TakeLife(damage);
    StatsTextProvider.TriggerOnHasLifeChange(statsController.life.ToString());
    StatsTextProvider.TriggerOnHasShieldChange(statsController.shield.ToString());
  }

  private void OnHasLevelUp(Character levelUpCharacter) {
    character = levelUpCharacter;
    SetConfig();
    StatsTextProvider.TriggerOnHasLifeChange(statsController.life.ToString());
    StatsTextProvider.TriggerOnHasShieldChange(statsController.shield.ToString());
  }

  private void OnDestroy() {
    StopAllCoroutines();
    UnsuscribeEvents();
  }

  private void OnDisable() {
    StopAllCoroutines();
    UnsuscribeEvents();
  }

  private void UnsuscribeEvents() {
    InputProvider.OnHasMove -= OnHasMove;
    InputProvider.OnHasShoot -= OnHasShoot;
    InputProvider.OnHasShootSpecial += OnHasShootSpecial;
    InputProvider.OnHasDamage += OnHasDamage;
    InputProvider.OnHasLevelUp += OnHasLevelUp;
  }

  public void DoMovement() {
    throw new System.NotImplementedException();
  }

  public void DoMovement(Vector3 direction) {
    transform.position = BoundaryBehaviour.Instance.GetClampPosition(transform.position);
    if (rigidBody2D is null) return;
    rigidBody2D.velocity = direction * character.speed * Time.fixedDeltaTime * 100;
  }
}