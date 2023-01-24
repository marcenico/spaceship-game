using UnityEngine;

public class GameManager : MonoBehaviour {
  private static GameManager instance;

  public static GameManager Instance {
    get {
      if (instance is null) {
        GameObject go = new GameObject("GameManager");
        go.AddComponent<GameManager>();
      }
      return instance;
    }
  }

  private void Awake() {
    instance = this;
  }
}