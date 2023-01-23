using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterConfig", menuName = "Character/Character Config", order = 0)]
public class Character : ScriptableObject {
  public float life = 100f;
  public float shield = 100f;
  public float speed = 4f;
  public Sprite skin = null;
  public GameObject shootPrefab = null;
  public GameObject shootSpecialPrefab = null;
  public float nextFire = 0.5f;
  public float nextFireSpecial = 10f;

}
