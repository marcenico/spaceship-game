public static class StatsTextProvider {
  public delegate void HasLifeChange(string life);
  public static event HasLifeChange OnHasLifeChange;

  public delegate void HasShieldChange(string shield);
  public static event HasShieldChange OnHasShieldChange;

  public delegate void HasExperienceChange(string experience);
  public static event HasExperienceChange OnHasExperienceChange;

  public delegate void HasWaveChange(string waveNumber);
  public static event HasWaveChange OnHasWaveChange;

  public delegate void HasStartCounterChange(float startCounterTime);
  public static event HasStartCounterChange OnHasStartCounterChange;

  public static void TriggerOnHasLifeChange(string life) {
    OnHasLifeChange?.Invoke(life);
  }

  public static void TriggerOnHasShieldChange(string shield) {
    OnHasShieldChange?.Invoke(shield);
  }

  public static void TriggerOnHasExperienceChange(string experience) {
    OnHasExperienceChange?.Invoke(experience);
  }

  public static void TriggerOnHasWaveChange(string waveNumber) {
    OnHasWaveChange?.Invoke(waveNumber);
  }

  public static void TriggerOnHasStartCounterChange(float startCounterTime) {
    OnHasStartCounterChange?.Invoke(startCounterTime);
  }
}

