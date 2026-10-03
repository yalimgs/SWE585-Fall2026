using UnityEngine;

public class ObjectController : MonoBehaviour
{
    // Rigidbody assigned via Unity GUI drag and drop
    public Rigidbody rb;
    
    // The amount of force to apply
    public float forceAmount = 2f;

    // FixedUpdate is called every physics step
    void FixedUpdate()
    {
        // Add a continuous forward force to the Rigidbody
        if (rb != null)
        {
            rb.AddForce(Vector3.left * forceAmount);
        }
    }
}