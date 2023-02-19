using UnityEngine;

[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(FollowPathController))]
[RequireComponent(typeof(OnTriggerDo))]
public class EnemyBehaviour : MonoBehaviour {
  [SerializeField] public Character character = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private StatsController statsController = null;
  private FollowPathController followPathController = null;
  private OnTriggerDo triggerDo = null;


  private void Awake() {
    followPathController = GetComponent<FollowPathController>();
    statsController = GetComponent<StatsController>();
    triggerDo = GetComponent<OnTriggerDo>();
  }

  private void OnEnable() {
    SetConfig();
  }

  private void OnDisable() {
    StopCoroutine(shootController.Shoot());
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  private void OnDestroy() {
    StopCoroutine(shootController.Shoot());
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  private void Update() {
    if (GameManager.Instance.isPlayerDead) return;
    if (character.canFire && shootController && spriteRenderer.isVisible) StartCoroutine(shootController.Shoot());
  }

  public void MakeDamage() {
    if (triggerDo.otherCollider.tag != "Player") return;
    InputProvider.TriggerOnHasDamage(character.damageOnTrigger);
  }

  public void GiveExperience() {
    GameManager.Instance.AddExperience(character.experienceOnDead);
  }

  private void SetConfig() {
    if (followPathController) followPathController.SetSpeed(character.speed);
    if (statsController) statsController.SetConfig(character);
    if (shootController) shootController.SetConfig(character);
    spriteRenderer.sprite = character.skin;
  }
}