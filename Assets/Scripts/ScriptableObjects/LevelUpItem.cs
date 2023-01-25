using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelUpItem", menuName = "LevelUpItem/LevelUpItem Config", order = 0)]
public class LevelUpItem : ScriptableObject {
  public Vector3 directionMovement = Vector3.zero;
  public float speed = 1f;
  public Character character = null;
  public Sprite skin = null;
}
