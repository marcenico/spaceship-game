using UnityEngine;
using System.Collections;

public class AutoDestroyObject : MonoBehaviour {
  [SerializeField] private bool onlyDeactivate = false;
  [SerializeField] private float timeOfLive = 0.5f;

  private void OnEnable() {
    StartCoroutine(CheckIfAlive());
  }

  private void OnDisable() {
    StopAllCoroutines();
  }

  private void OnDestroy() {
    StopAllCoroutines();
  }



  private IEnumerator CheckIfAlive() {
    yield return new WaitForSeconds(timeOfLive);
    if (!gameObject.activeInHierarchy) yield break;
    if (onlyDeactivate) {
      this.gameObject.SetActive(false);
    } else
      Destroy(this.gameObject);
  }
}