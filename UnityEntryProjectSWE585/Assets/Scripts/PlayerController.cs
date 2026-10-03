using UnityEngine;
using UnityEngine.InputSystem; // Required for the new Input System

public class PlayerController : MonoBehaviour
{
    // The Rigidbody of the player object, assigned via GUI
    public Rigidbody rb;
    
    // Speed/Force multiplier for movement
    public float moveSpeed = 50f;

    // FixedUpdate is used for physics calculations
    void FixedUpdate()
    {
        // Check if a keyboard is connected
        if (Keyboard.current == null) return;

        float moveHorizontal = 0f;
        float moveVertical = 0f;

        // Read input from WASD or Arrow Keys
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed) moveHorizontal += 1f;
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed) moveHorizontal -= 1f;
        if (Keyboard.current.wKey.isPressed || Keyboard.current.upArrowKey.isPressed) moveVertical += 1f;
        if (Keyboard.current.sKey.isPressed || Keyboard.current.downArrowKey.isPressed) moveVertical -= 1f;

        // Create a movement vector based on inputs (X and Z axes)
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // Add force to the object in the direction of the input
        if (rb != null)
        {
            rb.AddForce(movement * moveSpeed);
        }
    }
}