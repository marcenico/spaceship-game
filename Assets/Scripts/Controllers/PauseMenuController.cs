using UnityEngine;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour {
  [SerializeField] private Button resumeButton = null;
  [SerializeField] private Button restartButton = null;
  [SerializeField] private Button quitButton = null;

  private void Start() {
    resumeButton.onClick.AddListener(HandleResumeClick);
    restartButton.onClick.AddListener(HandleRestartClick);
    quitButton.onClick.AddListener(HandleQuitClick);
  }

  private void HandleResumeClick() {
    GameManager.Instance.TogglePause();
  }
  private void HandleRestartClick() {
    GameManager.Instance.RestartGame();
  }

  private void HandleQuitClick() {
    GameManager.Instance.QuitGame();
  }
}
