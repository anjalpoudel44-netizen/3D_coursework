using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform doorCube; // The visible door
    public Vector3 openPositionOffset = new Vector3(2, 0, 0); 
    public float speed = 3f;

    private Vector3 closedPosition;
    private Vector3 targetPosition;

    void Start()
    {
        // If you forgot to drag the door in, it uses itself
        if (doorCube == null) doorCube = transform;
        
        closedPosition = doorCube.localPosition;
        targetPosition = closedPosition;
    }

    void Update()
    {
        doorCube.localPosition = Vector3.Lerp(doorCube.localPosition, targetPosition, Time.deltaTime * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            targetPosition = closedPosition + openPositionOffset;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetPosition = closedPosition;
        }
    }
}