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
    PoolController.Instance.ReturnOneToPool(gameObject);
  }

  private void Update() {
    if (shootController) StartCoroutine(shootController.Shoot());
  }

  public void MakeDamage() {
    if (triggerDo is null || triggerDo.gameObjectTag != "Player") return;
    InputProvider.TriggerOnHasDamage(character.damageOnTrigger);
    triggerDo.statsTarget = null;
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