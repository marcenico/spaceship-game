using UnityEngine;

public class AutoScroller : MonoBehaviour {
  public float scrollSpeed = 0.5f;
  [SerializeField] private MeshRenderer mesh = null;

  private void Update() {
    Vector2 offset = new Vector2(0, Time.time * scrollSpeed);
    mesh.material.mainTextureOffset = offset;
  }
}