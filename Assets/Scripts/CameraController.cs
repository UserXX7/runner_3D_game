using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
         Vector3 newPosition = new Vector3(
            transform.position.x, // keeps the camera's x position the same
            transform.position.y, // keeps the camera's y position the same
            offset.z + target.position.z //follow player + offset
        );

        transform.position = Vector3.Lerp(
            transform.position, 
            newPosition, 
            10 * Time.deltaTime
        );
        
    }
}
