public static class StatsTextProvider {
  public delegate void HasLifeChange(string life);
  public static event HasLifeChange OnHasLifeChange;

  public delegate void HasShieldChange(string shield);
  public static event HasShieldChange OnHasShieldChange;

  public static void TriggerOnHasLifeChange(string life) {
    OnHasLifeChange?.Invoke(life);
  }

  public static void TriggerOnHasShieldChange(string shield) {
    OnHasShieldChange?.Invoke(shield);
  }
}

