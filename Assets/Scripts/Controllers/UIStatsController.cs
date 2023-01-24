using UnityEngine;
using TMPro;

public class UIStatsController : MonoBehaviour {
  [HideInInspector] public StatsController statsController = null;
  [SerializeField] private TextMeshProUGUI lifeText = null;
  [SerializeField] private TextMeshProUGUI shieldText = null;

  void Awake() {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player) statsController = player.GetComponent<StatsController>();
  }

  private void Start() {
    OnHasLifeChange(statsController.life.ToString());
    OnHasShieldChange(statsController.shield.ToString());
    StatsTextProvider.OnHasLifeChange += OnHasLifeChange;
    StatsTextProvider.OnHasShieldChange += OnHasShieldChange;
  }

  private void OnHasLifeChange(string life) {
    lifeText.text = life;
  }

  public void OnHasShieldChange(string shield) {
    shieldText.text = shield;
  }
}
