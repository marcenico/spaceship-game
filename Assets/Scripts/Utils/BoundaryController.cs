using UnityEngine;

[System.Serializable]
public class BoundaryController : MonoBehaviour {
  [HideInInspector] public float left;
  [HideInInspector] public float right;
  [HideInInspector] public float top;
  [HideInInspector] public float bottom;
  private int lastScreenWidth = 0;
  private int lastScreenHeight = 0;

  private void Awake() {
    SetBoundaries();
  }

  private void Update() {
    if (lastScreenWidth != Screen.width || lastScreenHeight != Screen.height) {
      lastScreenWidth = Screen.width;
      lastScreenHeight = Screen.height;
      SetBoundaries();
    }
  }

  private void SetBoundaries() {
    Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    left = lowerLeft.x + 1.4f;
    right = upperRight.x - 1.4f;
    top = upperRight.y - 1.4f;
    bottom = lowerLeft.y + 1.4f;
  }
}