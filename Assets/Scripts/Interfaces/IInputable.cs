using UnityEngine;

public interface IInputable {
  void Shoot();
  void ShootFirstAbility();
  void GetDirection(Vector3 direction);
}