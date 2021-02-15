public class BoundaryProvider {
  public delegate void GetBoundaries();
  public static event GetBoundaries OnGetBoundaries;

  public static void TriggerOnGetBoundaries() {
    OnGetBoundaries?.Invoke();
  }
}