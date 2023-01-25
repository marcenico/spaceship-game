using UnityEngine;
using System.Collections;

public class DestroyInvisible : MonoBehaviour {
  [SerializeField] private bool onlyDeactivate = true;
  [SerializeField] private float waitingTime = 0f;

  public void OnBecameInvisible() {
    if (onlyDeactivate) {
      if (gameObject.activeInHierarchy) {
        StartCoroutine(BecameInivisible());
      }
    } else {
      Destroy(gameObject, waitingTime);
    }
  }

  private IEnumerator BecameInivisible() {
    yield return new WaitForSeconds(waitingTime);
    gameObject.SetActive(false);
  }
}
