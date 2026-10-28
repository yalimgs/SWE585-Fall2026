using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// fire trap that turns on and off again and again
public class Trap : MonoBehaviour
{
    public float onTime = 2f;   // seconds the fire is on
    public float offTime = 2f;  // seconds the fire is off

    bool isOn = true;  // is the fire burning right now?
    Renderer fire;     // the part that draws the cube on screen

    void Start()
    {
        fire = GetComponent<Renderer>();
        StartCoroutine(FireLoop()); // start the on/off loop
    }

    // coroutine: it runs, waits a few seconds, then continues where it left off
    IEnumerator FireLoop()
    {
        while (true) // repeat forever
        {
            isOn = true;
            fire.enabled = true;   // show the fire
            yield return new WaitForSeconds(onTime);

            isOn = false;
            fire.enabled = false;  // hide the fire
            yield return new WaitForSeconds(offTime);
        }
    }

    // unity calls this again and again while something is inside the trap
    void OnTriggerStay(Collider other)
    {
            // unity calls this again and again while something is inside the trap
    void OnTriggerStay(Collider other)
    {
        // kill only the player, and only when the fire is on
        if (isOn && other.CompareTag("Player"))
        {
            GameManager.instance.Lose("You got burned by the fire!");
        }
    }
    }
}