using System.Collections;
using UnityEngine;

// fire trap that turns on and off again and again
public class Trap : MonoBehaviour
{
    public float onTime = 2f;      // seconds the fire is on
    public float offTime = 2f;     // seconds the fire is off
    public ParticleSystem flames;  // the fire effect (child object)

    bool isOn = true;  // is the fire burning right now?

    void Start()
    {
        GetComponent<Renderer>().enabled = false; // hide the red box, the flames show the trap now
        StartCoroutine(FireLoop());               // start the on/off loop
    }

    // coroutine: it runs, waits a few seconds, then continues where it left off
    IEnumerator FireLoop()
    {
        while (true) // repeat forever
        {
            isOn = true;
            flames.Play();  // start the fire
            yield return new WaitForSeconds(onTime);

            isOn = false;
            flames.Stop();  // stop making new flames, the old ones fade out
            yield return new WaitForSeconds(offTime);
        }
    }

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