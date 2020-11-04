using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputable {

  public void GetDirection(Vector3 direction) {
    InputProvider.TriggerOnHasMove(direction);
  }

  public void ShootPressed() {
    InputProvider.TriggerOnHasShoot();
  }

  private void Update() {
    GetDirection(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
    if (Input.GetButtonDown("Fire1")) ShootPressed();
  }
}