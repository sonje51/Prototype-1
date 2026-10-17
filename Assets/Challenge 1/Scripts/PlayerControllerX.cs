using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float baseSpeed;
    public float rotationSpeed;
    public InputAction MoveAction;

    [SerializeField] private float speed;
    [SerializeField] private float verticalInput;

    // private variables
    // Current input value (x = speed, y = up/dpwn), kept private for internal use
    [SerializeField] private Vector2 moveInput;

    // Start is called before the first frame update
    void Start()
    {
        MoveAction.Enable();
        baseSpeed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        // get the user's vertical input
        moveInput = Gamepad.current.leftStick.ReadValue();

        // increase the speed while user inputs values below -0.2 and above 0.2
        // When the user is between -0.2 and 0.2, then the speed will stay where they player left it
        if(moveInput.x < -0.2 | moveInput.x > 0.2) {
            speed += moveInput.x * 0.2f;
        }
        // 
        if (speed < baseSpeed) { speed = baseSpeed; }
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.left, rotationSpeed * Time.deltaTime * moveInput.y);
    }
}
