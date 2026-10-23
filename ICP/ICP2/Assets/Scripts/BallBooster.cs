using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBooster : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = new Vector3(-5, 0, 0);
    private Vector3 startPos;

    private Rigidbody rb;
    private bool hasHitBarrier = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // FixedUpdate is synchronized with Unity's physics timestep.
    void FixedUpdate()
    {
        rb.AddForce(direction);
    }

    // Called when the ball hits another collider
    void OnCollisionEnter(Collision collision)
    {
        // Only react to the first barrier (Brick Wall), only once
        if (collision.gameObject.CompareTag("Barrier") && !hasHitBarrier)
        {
            hasHitBarrier = true;
            transform.localScale = transform.localScale * 1.5f;      // make the ball bigger
            GetComponent<Renderer>().material.color = Color.red;     // make the ball red
        }
    }
}