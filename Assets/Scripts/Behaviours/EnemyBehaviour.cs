using UnityEngine;

[RequireComponent(typeof(StatsController))]
[RequireComponent(typeof(FollowPathController))]
public class EnemyBehaviour : MonoBehaviour {
  [SerializeField] public Character character = null;
  [SerializeField] private ShootController shootController = null;
  [SerializeField] private SpriteRenderer spriteRenderer = null;
  private StatsController statsController = null;
  private FollowPathController followPathController = null;


  private void Awake() {
    followPathController = GetComponent<FollowPathController>();
    statsController = GetComponent<StatsController>();
  }

  private void OnEnable() {
    SetConfig();
  }

  private void Update() {
    if (shootController) StartCoroutine(shootController.Shoot());
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


  private void OnDisable() {
    PoolController.Instance.ReturnOneToPool(gameObject);
  }
}