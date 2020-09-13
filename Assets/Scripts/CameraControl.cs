using UnityEngine;

public class CameraControl : MonoBehaviour {
  public Transform target;
  public Transform background1;
  public Transform background2;
  private float size;
  private Vector3 cameraTargetPos = new Vector3 ();
  private Vector3 background1TargetPos = new Vector3 ();
  private Vector3 background2TargetPos = new Vector3 ();

  private void Start () {
    size = background1.GetComponent<BoxCollider2D> ().size.y * background1.transform.localScale.y;
  }

  private void FixedUpdate () {
    CameraFollowTarget ();
    CheckBackgroundPositionUp ();
    CheckBackgroundPositionDown ();
  }

  private void CameraFollowTarget () {
    Vector3 targetPosition = SetPos (cameraTargetPos, target.position.x, target.position.y + 5, transform.position.z);
    transform.position = Vector3.Lerp (transform.position, targetPosition, 0.2f);
  }

  private void CheckBackgroundPositionUp () {
    if (transform.position.y >= background2.position.y) {
      background1.position = SetPos (background1TargetPos, background1.position.x, background2.position.y + size, background1.position.z);
      SwitchBackground ();
    }
  }

  private void CheckBackgroundPositionDown () {
    if (transform.position.y < background1.position.y) {
      background2.position = SetPos (background2TargetPos, background2.position.x, background1.position.y - size, background2.position.z);
      SwitchBackground ();
    }
  }

  private void SwitchBackground () {
    Transform temp = background1;
    background1 = background2;
    background2 = temp;
  }

  private Vector3 SetPos (Vector3 pos, float x, float y, float z) {
    pos.x = x;
    pos.y = y;
    pos.z = z;
    return pos;
  }
}