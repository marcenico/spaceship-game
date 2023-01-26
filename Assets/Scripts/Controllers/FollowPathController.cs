using UnityEngine;
using PathCreation;

public class FollowPathController : MonoBehaviour {
  public PathCreator pathCreator;
  public EndOfPathInstruction endOfPathInstruction;
  private float distanceTravelled;
  private Vector3 oldPosition = Vector3.zero;
  private float speed = 1f;
  [SerializeField] private float rotationSpeed = 1f;

  private void Start() {
    Debug.Log("Start");
    if (pathCreator is null) return;
    oldPosition = transform.position;
    pathCreator.pathUpdated += OnPathChanged;
  }

  private void FixedUpdate() {
    if (pathCreator is null) return;
    Vector3 oldPosition = transform.position;
    Move();
    RotateToDirection(oldPosition, transform.position);
  }

  private void OnEnable() {
    distanceTravelled = 0f;
    pathCreator.pathUpdated += OnPathChanged;
  }

  private void OnDisable() {
    pathCreator.pathUpdated -= OnPathChanged;
  }

  private void Move() {
    distanceTravelled += speed * Time.deltaTime;
    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
  }

  private void RotateToDirection(Vector3 oldPosition, Vector3 newPosition) {
    Vector3 moveDirection = newPosition - oldPosition;
    float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * (Mathf.Rad2Deg);

    if (oldPosition != Vector3.zero) {
      Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, moveDirection);
      transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime * 1000f);
    }
  }

  private void OnPathChanged() {
    distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
  }

  public void SetSpeed(float newSpeed) {
    speed = newSpeed;
  }

}