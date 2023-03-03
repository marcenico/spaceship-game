using UnityEngine;

public class MenuController : MonoBehaviour {
  [SerializeField] private Animation mainMenuAnimator = null;
  [SerializeField] private AnimationClip fadeInAnimation = null;
  [SerializeField] private AnimationClip fadeOutAnimation = null;

  public Events.EventFadeComplete OnMainMenuFadeComplete;

  private void Start() {
    GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
  }

  public void OnFadeOutComplete() {
    OnMainMenuFadeComplete.Invoke(true);
  }

  public void OnFadeInComplete() {
    OnMainMenuFadeComplete.Invoke(false);
    mainMenuAnimator.Play("AnimMainMenu");
    UIManager.Instance.SetDummyCameraActive(true);
  }

  public void FadeIn() {
    mainMenuAnimator.Stop();
    mainMenuAnimator.clip = fadeInAnimation;
    mainMenuAnimator.AddClip(fadeInAnimation, fadeInAnimation.name);
    mainMenuAnimator.Play();
  }

  public void FadeOut() {
    UIManager.Instance.SetDummyCameraActive(false);
    mainMenuAnimator.Stop();
    mainMenuAnimator.clip = fadeOutAnimation;
    mainMenuAnimator.AddClip(fadeOutAnimation, fadeOutAnimation.name);
    mainMenuAnimator.Play();
  }

  void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState) {
    if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNING) {
      FadeOut();
    }

    if (previousState != GameManager.GameState.RUNING && currentState == GameManager.GameState.PREGAME) {
      FadeIn();
    }
  }
}