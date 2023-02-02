using UnityEngine.Events;
using UnityEngine;

public class OnTriggerDo : MonoBehaviour {
  [SerializeField] private UnityEvent action = null;
  [HideInInspector] public StatsController statsTarget = null;
  [HideInInspector] public Collider2D otherCollider = null;

  private void OnTriggerEnter2D(Collider2D other) {
    otherCollider = other;
    statsTarget = other.gameObject.GetComponent<StatsController>();
    action.Invoke();
  }
}