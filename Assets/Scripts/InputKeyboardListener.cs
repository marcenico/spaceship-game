using UnityEngine;

public class InputKeyboardListener : MonoBehaviour, IInputable {
  private Vector3 direction = Vector3.zero;

  private void FixedUpdate() {
    GetDirection(Vector3Extension.SetPos(direction, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f));
  }

  private void Update() {
    if (Input.GetButton("Fire1")) ShootPressed();
  }

  public void GetDirection(Vector3 direction) {
    InputProvider.TriggerOnHasMove(direction);
  }

  public void ShootPressed() {
    InputProvider.TriggerOnHasShoot();
  }
}