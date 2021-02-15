using UnityEngine;

public class DestroyInvisible : MonoBehaviour {
  [SerializeField] private float waitingTime = 0f;

  public void OnBecameInvisible() {
    Destroy(transform.root.gameObject, waitingTime);
  }
}
