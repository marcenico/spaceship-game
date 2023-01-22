using UnityEngine;

public static class InputProvider {
  public delegate void HasMove(Vector3 direction);
  public static event HasMove OnHasMove;

  public delegate void HasShoot();
  public static event HasShoot OnHasShoot;

  public delegate void HasShootFirstHability();
  public static event HasShootFirstHability OnHasShootFirstHability;

  public static void TriggerOnHasMove(Vector3 direction) {
    OnHasMove?.Invoke(direction);
  }

  public static void TriggerOnHasShoot() {
    OnHasShoot?.Invoke();
  }

  public static void TriggerOnHasShootSpecial() {
    OnHasShootFirstHability?.Invoke();
  }
}