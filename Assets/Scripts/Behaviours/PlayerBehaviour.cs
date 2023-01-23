using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(MovementController))]
public class PlayerBehaviour : MonoBehaviour {
  [SerializeField] private Character character = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private StatsController statsController = null;
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
    statsController = GetComponent<StatsController>();
  }

  private void Start() {
    SetConfig();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
    InputProvider.OnHasShootSpecial += OnHasShootSpecial;
    InputProvider.OnHasDamage += OnHasDamage;
  }

  private void SetConfig() {
    if (movementController) movementController.SetConfig(character);
    if (statsController) statsController.SetConfig(character.life, character.shield);
    if (shootController) shootController.SetConfig(character);
    spriteRenderer.sprite = character.skin;
  }

  private void OnHasMove(Vector3 direction) {
    Assert.IsNotNull(movementController, message: $"No debe ser nulo {movementController}");
    transform.position = BoundaryBehaviour.Instance.GetClampPosition(transform.position);
    movementController.direction = direction;
    movementController.DoMovement();
  }

  private void OnHasShoot() {
    if (!shootController) return;
    StartCoroutine(shootController.Shoot());
  }

  private void OnHasShootSpecial() {
    if (!shootController) return;
    StartCoroutine(shootController.ShootSpecial());
  }

  private void OnHasDamage(float damage) {
    statsController.TakeLife(damage);
  }

  private void OnDestroy() {
    UnsuscribeEvents();
  }

  private void OnDisable() {
    UnsuscribeEvents();
  }

  private void UnsuscribeEvents() {
    InputProvider.OnHasMove -= OnHasMove;
    InputProvider.OnHasShoot -= OnHasShoot;
    InputProvider.OnHasShoot -= OnHasShoot;
  }
}