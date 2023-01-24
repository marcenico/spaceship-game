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

  private float experience = 0f;
  [SerializeField] private PlayerLevel[] playerLevelConfig = null;

  private void Awake() {
    instance = this;
  }

  public void AddExperience(float newExperience) {
    experience += newExperience;
    StatsTextProvider.TriggerOnHasExperienceChange(experience.ToString());
    LevelUp();
  }

  public void LevelUp() {
    for (int i = playerLevelConfig.Length - 1; i >= 0; i--) {
      if (experience >= playerLevelConfig[i].experienceToLevelUp) {
        InputProvider.TriggerOnHasLevelUp(playerLevelConfig[i].characterConfig);
        break;
      }
    }
  }
}