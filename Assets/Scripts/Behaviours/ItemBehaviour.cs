using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ItemBehaviour : MonoBehaviour, IMovable {
  [SerializeField] private LevelUpItem levelUpItem = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private Rigidbody2D rigidBody2D = null;

  private void Awake() {
    rigidBody2D = GetComponent<Rigidbody2D>();
  }

  private void OnEnable() {
    SetConfig();
  }

  private void SetConfig() {
    spriteRenderer.sprite = levelUpItem.skin;
  }

  private void FixedUpdate() {
    DoMovement();
  }

  public void LevelUpPlayer() {
    InputProvider.TriggerOnHasLevelUp(levelUpItem.character);
  }

  public void DoMovement() {
    if (rigidBody2D is null) return;
    rigidBody2D.velocity = levelUpItem.directionMovement * levelUpItem.speed * Time.fixedDeltaTime * 100;
  }

  public void DoMovement(Vector3 direction) {
    throw new System.NotImplementedException();
  }
}
