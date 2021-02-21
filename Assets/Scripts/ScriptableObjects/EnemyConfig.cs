using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyConfig", menuName = "Enemy/Enemy Config", order = 0)]
public class EnemyConfig : ScriptableObject {
  public float speed;
  public Sprite sprite;
}
