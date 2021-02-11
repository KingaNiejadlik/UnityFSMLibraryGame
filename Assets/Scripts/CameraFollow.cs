using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 0.125f;
    public Vector3 offset;
    public Vector3 rotation;

    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smothPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
        transform.position = smothPosition;
        transform.eulerAngles = rotation;
        
    }

}
