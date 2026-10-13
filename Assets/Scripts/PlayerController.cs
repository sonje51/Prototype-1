using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // public variables
    // Movement tuning (editable in inspector)
    // easily set speed as needed in Unity, 'f' tells Unity 5.0 is a float 
    public float speed = 5.0f;
    public float turnSpeed;
    // Input System action exposed in Inspector for binding (WASD/arrow keys)
    public InputAction MoveAction;

    // private variables
    // Current input value (x = left/right, y = forward/back), kept private for internal use
    private Vector2 moveInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoveAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Read the 2D vec from the MoveAction (x = hor, y = vert)
        moveInput = MoveAction.ReadValue<Vector2>();

        // move the vehicle forward along local Z using y component
        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveInput.y);

        // left/right rotation around local y (yaw) using x component
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * moveInput.x);
        // transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * moveInput.x);
    }
}
