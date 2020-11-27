using UnityEngine;

public class Instanciator : MonoBehaviour {
  public GameObject prefab;

  public void DoInstanciate() {
    Instantiate(prefab, transform.position, transform.rotation);
  }
}
