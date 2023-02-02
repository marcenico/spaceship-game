using UnityEngine;
using System.Collections;


public class DestroyObject : MonoBehaviour {
  [SerializeField] private bool onlyDeactivate = true;

  public void DoDestroy() {
    if (onlyDeactivate) gameObject.SetActive(false);
    else Destroy(gameObject);
  }
}
