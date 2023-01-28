using UnityEngine;

[RequireComponent(typeof(OnTriggerDo))]
public class Instanciator : MonoBehaviour {
  public GameObject prefab;
  private OnTriggerDo triggerDo = null;

  private void Awake() {
    triggerDo = GetComponent<OnTriggerDo>();
  }

  public void DoInstanciate() {
    if (triggerDo is null || triggerDo.gameObjectTag == "Wall") return;
    Instantiate(prefab, transform.position, transform.rotation);
  }
}
