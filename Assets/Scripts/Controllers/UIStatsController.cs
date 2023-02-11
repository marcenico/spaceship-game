using UnityEngine;
using TMPro;
using System.Collections;

public class UIStatsController : MonoBehaviour {
  [HideInInspector] public StatsController statsController = null;
  [SerializeField] private TextMeshProUGUI lifeValue = null;
  [SerializeField] private TextMeshProUGUI shieldValue = null;
  [SerializeField] private TextMeshProUGUI experienceValue = null;

  [SerializeField] private TextMeshProUGUI waveValue = null;
  [SerializeField] private GameObject nextWaveTimeText = null;
  [SerializeField] private TextMeshProUGUI nextWaveTimeValue = null;

  void Awake() {
    GameObject player = GameObject.FindGameObjectWithTag("Player");
    if (player) statsController = player.GetComponent<StatsController>();

    OnHasLifeChange(statsController.life.ToString());
    OnHasShieldChange(statsController.shield.ToString());
    StatsTextProvider.OnHasLifeChange += OnHasLifeChange;
    StatsTextProvider.OnHasShieldChange += OnHasShieldChange;
    StatsTextProvider.OnHasExperienceChange += OnHasExperienceChange;
    StatsTextProvider.OnHasWaveChange += OnHasWaveChange;
    StatsTextProvider.OnHasStartCounterChange += OnHasStartCounterChange;
  }

  private void Start() {
    if (!statsController) return;

  }

  private void OnDisable() {
    UnsuscribeEvents();
  }

  private void OnDestroy() {
    UnsuscribeEvents();
  }

  private void UnsuscribeEvents() {
    StatsTextProvider.OnHasLifeChange -= OnHasLifeChange;
    StatsTextProvider.OnHasShieldChange -= OnHasShieldChange;
    StatsTextProvider.OnHasExperienceChange -= OnHasExperienceChange;
    StatsTextProvider.OnHasWaveChange -= OnHasWaveChange;
    StatsTextProvider.OnHasStartCounterChange -= OnHasStartCounterChange;
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

  public void OnHasStartCounterChange(float startCounterTime) {
    StartCoroutine(StartNextWaveCounter(startCounterTime));
  }

  private IEnumerator StartNextWaveCounter(float startCounterTime) {
    nextWaveTimeText.SetActive(true);
    nextWaveTimeValue.gameObject.SetActive(true);
    float counter = startCounterTime;

    while (counter >= 0) {
      nextWaveTimeValue.text = counter.ToString();
      counter--;

      yield return new WaitForSeconds(1f);

      if (counter == 0) {
        nextWaveTimeText.SetActive(false);
        nextWaveTimeValue.gameObject.SetActive(false);
        GameManager.Instance.AddWaveNumber();
      }
    }

  }
}
