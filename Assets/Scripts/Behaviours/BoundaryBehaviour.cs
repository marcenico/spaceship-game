using UnityEngine;

[System.Serializable]
public class Boundary {
  public float left = 0;
  public float right = 0;
  public float top = 0;
  public float bottom = 0;
}

public class BoundaryBehaviour : MonoBehaviour {
  private Boundary boundary = new Boundary();
  public static BoundaryBehaviour Instance;

  private void Awake() {
    if (Instance != null) {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    BoundaryProvider.OnGetBoundaries += OnGetBoundaries;
  }

  private void OnGetBoundaries() {
    Vector3 lowerLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
    Vector3 upperRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
    boundary.left = lowerLeft.x + 1.4f;
    boundary.right = upperRight.x - 1.4f;
    boundary.top = upperRight.y - 1.4f;
    boundary.bottom = lowerLeft.y + 1.4f;
  }

  public Vector3 GetClampPosition(Vector3 position) {
    float x = Mathf.Clamp(position.x, boundary.left, boundary.right);
    float y = Mathf.Clamp(position.y, boundary.bottom, boundary.top);
    return new Vector3(x, y);
  }

  private void OnDestroy() {
    BoundaryProvider.OnGetBoundaries -= OnGetBoundaries;
  }
}