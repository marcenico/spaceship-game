using UnityEngine;
public static class Vector3Extension {

  public static Vector3 SetPos(Vector3 pos, float x, float y, float z) {
    pos.x = x;
    pos.y = y;
    pos.z = z;
    return pos;
  }
}