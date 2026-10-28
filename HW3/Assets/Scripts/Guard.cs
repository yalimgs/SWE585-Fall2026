using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// guard that walks between two points and catches the player if he gets too close in front of it
public class Guard : MonoBehaviour
{
    public Vector3 pointA;           // first end of the patrol (type it in the inspector)
    public Vector3 pointB;           // second end of the patrol
    public float speed = 2f;         // walking speed in m/s
    public float waitTime = 1f;      // seconds it waits at each end
    public float viewDistance = 4f;  // how far it can see in metres
    public float viewAngle = 60f;    // how wide it can see to the left and right in degrees

    Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // find the player once
        transform.position = pointA;                          // start at point a
        StartCoroutine(Patrol());                             // start walking
    }

    // coroutine: walk to b, wait, walk to a, wait, forever
    IEnumerator Patrol()
    {
        while (true)
        {
            yield return StartCoroutine(WalkTo(pointB));
            yield return new WaitForSeconds(waitTime);
            yield return StartCoroutine(WalkTo(pointA));
            yield return new WaitForSeconds(waitTime);
        }
    }

    // coroutine: move a little bit every frame until we reach the target
    IEnumerator WalkTo(Vector3 target)
    {
        transform.LookAt(target); // turn to face where we are going
        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null; // wait one frame, then continue
        }
    }

    // every frame check if the guard can see the player
    void Update()
    {
        Vector3 toPlayer = player.position - transform.position;
        toPlayer.y = 0; // only look left/right/forward, ignore height

        bool close = toPlayer.magnitude < viewDistance;
        bool inFront = Vector3.Angle(transform.forward, toPlayer) < viewAngle;

        if (close && inFront)
        {
            // make sure there is no wall between the guard and the player
            RaycastHit hit;
            if (Physics.Raycast(transform.position, toPlayer.normalized, out hit, viewDistance) && hit.transform == player)
            {
                Debug.Log("caught by the guard!");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // restart the level
            }
        }
    }
}