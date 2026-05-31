using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1; // 0: Left Lane, 1: Middle Lane, 2: Right Lane
    public float laneDistance = 4; // Distance between two lanes

    public float jumpForce;
    public float gravity = -10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
         direction.z = forwardSpeed;
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        float targetx = (desiredLane - 1) * laneDistance;
        direction.x = (targetx - transform.position.x) * 10f;

        //Jump and Gravity
        if (controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
               Jump();
            }
            else
            {
                direction.y = -1;   
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }
    }

    private void Jump()
    {
        direction.y = jumpForce;
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.deltaTime);
    } 
    
}
