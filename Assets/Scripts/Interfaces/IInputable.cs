using UnityEngine;

public interface IInputable {
  void Shoot();
  void ShootSpecial();
  void GetDirection(Vector3 direction);
}