using UnityEngine.Events;
using UnityEngine;

public class OnTriggerDo : MonoBehaviour {
  [SerializeField] private UnityEvent action = null;
  private GameObject objectThatCollided;

  private void OnTriggerEnter2D(Collider2D collider) {
    objectThatCollided = collider.gameObject;
    action.Invoke();
  }
}