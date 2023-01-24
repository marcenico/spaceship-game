using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerLevelConfig", menuName = "PlayerLevel/PlayerLevel Config", order = 0)]
public class PlayerLevel : ScriptableObject {
  public Character characterConfig = null;
  public float experienceToLevelUp = 0f;
}
