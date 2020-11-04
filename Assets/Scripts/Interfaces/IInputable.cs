using UnityEngine;

public interface IInputable {
  void ShootPressed();
  void GetDirection(Vector3 direction);
}