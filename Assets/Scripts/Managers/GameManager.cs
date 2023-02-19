using UnityEngine;

public class GameManager : MonoBehaviour {
  #region Singleton Pattern
  private static GameManager instance;

  public static GameManager Instance {
    get {
      if (instance is null) {
        GameObject go = new GameObject("GameManager");
        go.AddComponent<GameManager>();
      }
      return instance;
    }
  }
  #endregion

  [SerializeField] private Character[] characters = null;
  private float experience = 0f;
  private int playerLevel = 1;
  [HideInInspector] public bool isPlayerDead = false;
  [HideInInspector] public int waveNumber = 0;

  private void Awake() {
    instance = this;
  }

  public void AddExperience(float newExperience) {
    experience += newExperience;
    StatsTextProvider.TriggerOnHasExperienceChange(experience.ToString());
    LevelUp();
  }

  public void LevelUp() {
    if (characters is null) return;

    for (int i = 0; i < characters.Length; i++) {
      if (characters[i].playerLevel is null) continue;

      PlayerLevel playerLevelConfig = characters[i].playerLevel;
      if (playerLevel < playerLevelConfig.levelNumber && experience >= playerLevelConfig.experienceToLevelUp) {
        playerLevel += 1;
        InputProvider.TriggerOnHasLevelUp(characters[i]);
        return;
      }
    }
  }

  public void AddWaveNumber() {
    waveNumber++;
    StatsTextProvider.TriggerOnHasWaveChange(waveNumber.ToString());
  }

  public void StartNextWaveCounter(float startCounterTime) {
    StatsTextProvider.TriggerOnHasStartCounterChange(startCounterTime);
  }

}