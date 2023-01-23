using UnityEngine;
using System;

[RequireComponent(typeof(OnDefeatDo))]
public class StatsController : MonoBehaviour {
  [ReadOnly] public float life = 100f;
  [ReadOnly] public float shield = 100f;
  private OnDefeatDo onDefeatDo;

  private void Awake() {
    onDefeatDo = GetComponent<OnDefeatDo>();
  }

  public void SetConfig(Character character) {
    life = character.life;
    shield = character.shield;
  }

  public void TakeLife(float damage) {
    damage = TakeShield(damage);
    life -= damage;
    IsDefeated();
  }


  private float TakeShield(float damage) {
    if (shield <= 0) return damage;
    float previousShield = shield;
    shield -= damage;
    damage -= previousShield;

    shield = Math.Max(0f, shield);
    return Math.Max(0f, damage);
  }

  private void IsDefeated() {
    if (life > 0f) return;
    onDefeatDo.action.Invoke();
  }
}
