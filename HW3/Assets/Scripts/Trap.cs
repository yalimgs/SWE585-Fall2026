using System.Collections;
using UnityEngine;

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
}