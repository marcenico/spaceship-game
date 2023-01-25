using UnityEngine;

[RequireComponent(typeof(MovementController))]
public class ItemBehaviour : MonoBehaviour {
  [SerializeField] private LevelUpItem levelUpItem = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private MovementController movementController = null;

  private void Awake() {
    movementController = GetComponent<MovementController>();
  }

  private void FixedUpdate() {
    movementController.DoMovement();
  }

  private void OnEnable() {
    SetConfig();
  }

  private void SetConfig() {
    spriteRenderer.sprite = levelUpItem.skin;
    if (movementController) {
      movementController.SetDirection(levelUpItem.directionMovement);
      movementController.SetSpeed(levelUpItem.speed);
    }
  }

  public void LevelUpPlayer() {
    InputProvider.TriggerOnHasLevelUp(levelUpItem.character);
  }
}
