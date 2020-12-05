using UnityEngine;
using System.Collections;

public class AutoDestroyObject : MonoBehaviour {
  public bool OnlyDeactivate;

  private void OnEnable() {
    StartCoroutine("CheckIfAlive");
  }

  private IEnumerator CheckIfAlive() {
    yield return new WaitForSeconds(0.5f);
    if (OnlyDeactivate) {
      this.gameObject.SetActive(false);
    } else
      GameObject.Destroy(this.gameObject);
  }
}