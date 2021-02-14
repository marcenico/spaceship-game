using UnityEngine;

[RequireComponent(typeof(BoundaryController))]
public class GameManager : MonoBehaviour {
  private static GameManager instance;
  public static GameManager Instance { get { return instance; } }
  public BoundaryController boundaryController = null;

  private void Awake() {
    if (instance != null && instance != this) {
      Destroy(this.gameObject);
      return;
    } else {
      instance = this;
    }

    boundaryController = GetComponent<BoundaryController>();
  }
}