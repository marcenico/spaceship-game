using UnityEngine.Events;
using UnityEngine;

[System.Serializable]
public class MyEvent : UnityEvent<GameObject> { }

public class OnTriggerDo : MonoBehaviour {
  [SerializeField] private MyEvent action = null;
  private GameObject objectThatCollided;

  private void OnTriggerEnter2D(Collider2D collider) {
    Debug.Log(collider);
    objectThatCollided = collider.gameObject;
    action.Invoke(objectThatCollided);
  }
}