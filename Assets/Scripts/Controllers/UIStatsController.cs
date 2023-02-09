using UnityEngine;
using TMPro;

public class UIStatsController : MonoBehaviour {
  [HideInInspector] public StatsController statsController = null;
  [SerializeField] private TextMeshProUGUI lifeValue = null;
  [SerializeField] private TextMeshProUGUI shieldValue = null;
  [SerializeField] private TextMeshProUGUI experienceValue = null;

  [SerializeField] private TextMeshProUGUI waveValue = null;

  void Awake() {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player) statsController = player.GetComponent<StatsController>();
  }

  private void Start() {
    if (!statsController) return;

    OnHasLifeChange(statsController.life.ToString());
    OnHasShieldChange(statsController.shield.ToString());
    StatsTextProvider.OnHasLifeChange += OnHasLifeChange;
    StatsTextProvider.OnHasShieldChange += OnHasShieldChange;
    StatsTextProvider.OnHasExperienceChange += OnHasExperienceChange;
    StatsTextProvider.OnHasWaveChange += OnHasWaveChange;
  }

  private void OnHasLifeChange(string life) {
    lifeValue.text = life;
  }

  public void OnHasShieldChange(string shield) {
    shieldValue.text = shield;
  }

  public void OnHasExperienceChange(string experience) {
    experienceValue.text = experience;
  }

  public void OnHasWaveChange(string waveNumber) {
    waveValue.text = waveNumber;
  }
}
