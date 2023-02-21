using UnityEngine;
using PathCreation;
using System.Collections.Generic;

public class FollowPathController : MonoBehaviour, IMovable {
  public List<PathCreator> possiblePaths = new List<PathCreator>();
  public EndOfPathInstruction endOfPathInstruction;
  private PathCreator pathCreator = null;
  private float distanceTravelled;
  private Vector3 oldPosition = Vector3.zero;
  [SerializeField] private float speed = 1f;
  [SerializeField] private float rotationSpeed = 1f;

  private void Awake() {
    if (possiblePaths == null || possiblePaths.Count == 0) return;
    pathCreator = possiblePaths[(Random.Range(0, possiblePaths.Count))];
  }

  private void Start() {
    if (pathCreator is null) return;
    oldPosition = transform.position;
    pathCreator.pathUpdated += OnPathChanged;
  }

  private void FixedUpdate() {
    if (pathCreator is null) return;
    Vector3 oldPosition = transform.position;
    DoMovement();
    RotateToDirection(oldPosition, transform.position);
  }

  private void OnEnable() {
    distanceTravelled = 0f;
    pathCreator.pathUpdated += OnPathChanged;
  }

  private void OnDisable() {
    pathCreator.pathUpdated -= OnPathChanged;
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

  public void DoMovement() {
    distanceTravelled += speed * Time.deltaTime;
    transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
  }

  public void DoMovement(Vector3 direction) {
    throw new System.NotImplementedException();
  }
}