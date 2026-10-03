using UnityEngine;
using UnityEngine.InputSystem;

public class ObjectSpawner : MonoBehaviour
{
    // Prefab assigned via Unity GUI drag and drop
    public GameObject objectPrefab;

    // Update is called once per frame
    void Update()
    {
        // Check if keyboard exists and the Space key was pressed this frame
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            // Instantiate the prefab at this object's current position
            if (objectPrefab != null)
            {
                Instantiate(objectPrefab, transform.position, transform.rotation);
            }
        }
    }
}