using UnityEngine;

[CreateAssetMenu(fileName = "NewProjectile", menuName = "Projectile/Projectile Config", order = 0)]
public class Projectile : ScriptableObject {
  public float damage = 20f;
  public GameObject skin = null;
}
