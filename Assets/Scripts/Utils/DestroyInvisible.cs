using UnityEngine;
using System.Collections;

public class DestroyInvisible : MonoBehaviour {
  [SerializeField] private bool onlyDeactivate = true;
  [SerializeField] private float waitingTime = 0f;
  private bool isVisible;

  private void Awake() {
    isVisible = GetComponent<Renderer>().isVisible;
  }

  public void OnBecameInvisible() {
    if (!transform.root.gameObject.activeSelf || isVisible) return;

    if (onlyDeactivate) {
      StartCoroutine(BecameInivisible());
      return;
    }

    Destroy(transform.root.gameObject, waitingTime);
  }

  private IEnumerator BecameInivisible() {
    yield return new WaitForSeconds(waitingTime);
    transform.root.gameObject.SetActive(false);
  }

  private void OnDestroy() {
    StopAllCoroutines();
  }
}
