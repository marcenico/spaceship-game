using UnityEngine.Events;
using UnityEngine;

public class OnTriggerDo : MonoBehaviour {
  [SerializeField] private UnityEvent action = null;
  [HideInInspector] public StatsController statsTarget = null;

  private void OnTriggerEnter2D(Collider2D collider) {
    statsTarget = collider.gameObject.GetComponent<StatsController>();
    action.Invoke();
  }
}