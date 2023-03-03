using UnityEngine;

public class UIManager : Singleton<UIManager> {
  [SerializeField] private MenuController mainMenu = null;
  [SerializeField] private PauseMenuController pauseMenu = null;
  [SerializeField] private Camera dummyCamera = null;
  public Events.EventFadeComplete OnMainMenuFadeComplete;

  private void Start() {
    mainMenu.OnMainMenuFadeComplete.AddListener(HandleMainMenuFadeComplete);
    GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
  }

  private void HandleMainMenuFadeComplete(bool arg0) {
    OnMainMenuFadeComplete.Invoke(arg0);
  }

  void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState) {
    pauseMenu.gameObject.SetActive(currentState == GameManager.GameState.PAUSED);
  }


  private void Update() {
    if (GameManager.Instance.CurrentGameState != GameManager.GameState.PREGAME) {
      return;
    }

    if (Input.GetKeyDown(KeyCode.Space) && dummyCamera.gameObject.activeInHierarchy) {
      GameManager.Instance.StartGame();
    }
  }

  public void SetDummyCameraActive(bool active) {
    dummyCamera.gameObject.SetActive(active);
  }

}