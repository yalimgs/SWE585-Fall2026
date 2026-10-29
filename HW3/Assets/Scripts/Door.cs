using System.Collections;
using UnityEngine;

// opens the door wings inwards when the key hits the door, then the player wins
public class Door : MonoBehaviour
{
    public Transform wingA;        // first door wing (closed at 90 degrees)
    public Transform wingB;        // second door wing (closed at -90 degrees)
    public float openAngle = 90f;  // how far each wing turns when it opens
    public float openTime = 1f;    // seconds it takes to open

    bool opened = false;

    // unity calls this by itself when something hits the door
    void OnCollisionEnter(Collision collision)
    {
        // only the key can open the door, and only once
        // the collider stays on, so nobody can walk through the doorway
        if (collision.gameObject.name == "Key" && !opened)
        {
            opened = true;
            StartCoroutine(Open());
        }
    }

    // coroutine: turn both wings inwards a little every frame, then show the win screen
    IEnumerator Open()
    {
        Quaternion aStart = wingA.localRotation;
        Quaternion bStart = wingB.localRotation;
        Quaternion aEnd = aStart * Quaternion.Euler(0f, -openAngle, 0f); // 90 -> 0 (inwards)
        Quaternion bEnd = bStart * Quaternion.Euler(0f, openAngle, 0f);  // -90 -> 0 (inwards)

        float t = 0f; // goes from 0 (closed) to 1 (open)
        while (t < 1f)
        {
            t += Time.deltaTime / openTime;
            wingA.localRotation = Quaternion.Slerp(aStart, aEnd, t);
            wingB.localRotation = Quaternion.Slerp(bStart, bEnd, t);
            yield return null; // wait one frame, then continue
        }

        GameManager.instance.Win(); // the door is fully open: the player wins
    }
}