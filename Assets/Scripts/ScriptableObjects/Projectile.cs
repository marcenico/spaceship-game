using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "Projectile/Projectile Config", order = 0)]
public class Projectile : ScriptableObject {
  [Range(0, 8)] public float speed = 3f;
  public float damage = 20f;
}
