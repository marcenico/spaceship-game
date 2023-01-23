using UnityEngine;
using System;

public class StatsController : MonoBehaviour {
  [ReadOnly] public float life = 100f;
  [ReadOnly] public float shield = 100f;

  public void SetConfig(float lifeParam = 100f, float shieldParam = 100f) {
    life = lifeParam;
    shield = shieldParam;
  }

  public void TakeLife(float damage) {
    damage = TakeShield(damage);
    life -= damage;
  }


  private float TakeShield(float damage) {
    if (shield <= 0) return damage;
    float previousShield = shield;
    shield -= damage;
    damage -= previousShield;

    shield = Math.Max(0f, shield);
    return Math.Max(0f, damage);
  }
}
