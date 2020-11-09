 using UnityEngine.Events;
 using UnityEngine;

 public class OnTriggerDo : MonoBehaviour {
   [SerializeField] private UnityEvent action = null;
   private GameObject objectThatCollided;

   private void OnTriggerEnter2D(Collider2D collider) {
     objectThatCollided = collider.gameObject;
     action.Invoke();
   }

   public void DestroyObjectThatCollided() {
     if (objectThatCollided == null) return;
     switch (objectThatCollided.tag) {
       case "Player":
         break;
       case "Enemy":
         break;
       default:
         Destroy(objectThatCollided);
         break;
     }
   }
 }