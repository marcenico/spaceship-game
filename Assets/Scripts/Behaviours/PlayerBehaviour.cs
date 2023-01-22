using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(MovementController))]
public class PlayerBehaviour : MonoBehaviour {
  [SerializeField] private PlayerConfig playerConfig = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void Start() {
    SetConfig();
    InputProvider.OnHasMove += OnHasMove;
    InputProvider.OnHasShoot += OnHasShoot;
    InputProvider.OnHasShootFirstHability += OnHasShootFirstHability;
  }

  private void SetConfig() {
    if (movementController) movementController.SetConfig(playerConfig);
    if (shootController) shootController.SetConfig(playerConfig);
    spriteRenderer.sprite = playerConfig.skin;
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

  private void OnHasShootFirstHability() {
    if (!shootController) return;
    StartCoroutine(shootController.ShootSpecial());
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