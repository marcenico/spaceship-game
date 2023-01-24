using UnityEngine;

public class ScenarioWalls : MonoBehaviour {
  [SerializeField] private GameObject wallLeft = null;
  [SerializeField] private GameObject wallRight = null;
  [SerializeField] private GameObject wallTop = null;
  [SerializeField] private GameObject wallBottom = null;
  private Camera cameraMain;

  private void Awake() {
    cameraMain = Camera.main;
  }

  private void Update() {
    SetWallsPositions();
    ScaleWalls();
  }

  private void SetWallsPositions() {
    wallLeft.transform.position = cameraMain.ViewportToWorldPoint(new Vector2(-0.2f, 0.5f));
    wallRight.transform.position = cameraMain.ViewportToWorldPoint(new Vector2(1.2f, 0.5f));
    wallTop.transform.position = cameraMain.ViewportToWorldPoint(new Vector2(0.5f, 1.2f));
    wallBottom.transform.position = cameraMain.ViewportToWorldPoint(new Vector2(0.5f, -0.2f));
  }

  private void ScaleWalls() {
    double width = cameraMain.orthographicSize * 2.0 * Screen.width / Screen.height;
    double height = cameraMain.orthographicSize * 2.0;
    wallBottom.transform.localScale = new Vector3(0.1f, (float)width, 0.1f);
    wallTop.transform.localScale = new Vector3(0.1f, (float)width, 0.1f);
    wallLeft.transform.localScale = new Vector3(0.1f, (float)height, 0.1f);
    wallRight.transform.localScale = new Vector3(0.1f, (float)height, 0.1f);
  }
}