using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    private Vector3 offset;
    public float smoothSpeed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPos;
        
    }
}
