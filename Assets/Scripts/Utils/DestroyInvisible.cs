using UnityEngine;

public class DestroyInvisible : MonoBehaviour {
  public void OnBecameInvisible() {
    Destroy(transform.root.gameObject);
  }
}
