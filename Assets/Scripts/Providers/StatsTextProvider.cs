public static class StatsTextProvider {
  public delegate void HasLifeChange(string life);
  public static event HasLifeChange OnHasLifeChange;

  public delegate void HasShieldChange(string shield);
  public static event HasShieldChange OnHasShieldChange;

  public delegate void HasExperienceChange(string experience);
  public static event HasExperienceChange OnHasExperienceChange;

  public static void TriggerOnHasLifeChange(string life) {
    OnHasLifeChange?.Invoke(life);
  }

  public static void TriggerOnHasShieldChange(string shield) {
    OnHasShieldChange?.Invoke(shield);
  }

  public static void TriggerOnHasExperienceChange(string experience) {
    OnHasExperienceChange?.Invoke(experience);
  }
}

