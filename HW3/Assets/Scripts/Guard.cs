using System.Collections;
using UnityEngine;

// guard that walks between two points and catches the player if he gets too close in front of it
public class Guard : MonoBehaviour
{
    public Vector3 pointA;           // first end of the patrol (type it in the inspector)
    public Vector3 pointB;           // second end of the patrol
    public float speed = 2f;         // walking speed in m/s
    public float waitTime = 1f;      // seconds it waits at each end
    public float turnSpeed = 180f;   // how fast it turns around in degrees per second
    public float viewDistance = 4f;  // how far it can see in metres
    public float viewAngle = 60f;    // how wide it can see to the left and right in degrees

    Transform player;
    Animator anim; // the animator on the robot model inside the guard

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // find the player once
        anim = GetComponentInChildren<Animator>();           // find the robot's animator

        // tell the animation the robot stands on the ground and plays at normal speed
        anim.SetBool("Grounded", true);
        anim.SetFloat("MotionSpeed", 1f);

        transform.position = pointA; // start at point a
        StartCoroutine(Patrol());    // start walking
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

    // coroutine: turn to the target, then move a little bit every frame until we reach it
    IEnumerator WalkTo(Vector3 target)
    {
        yield return StartCoroutine(TurnTo(target)); // turn slowly to face where we are going

        anim.SetFloat("Speed", speed); // play the walk animation

        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null; // wait one frame, then continue
        }

        anim.SetFloat("Speed", 0f); // arrived: play the idle animation
    }

    // coroutine: turn a little bit every frame until we face the target
    IEnumerator TurnTo(Vector3 target)
    {
        Quaternion goal = Quaternion.LookRotation(target - transform.position); // the direction we want to face

        while (Quaternion.Angle(transform.rotation, goal) > 1f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, goal, turnSpeed * Time.deltaTime);
            yield return null; // wait one frame, then continue
        }

        transform.rotation = goal; // finish the turn exactly
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
                GameManager.instance.Lose("A guard caught you!");
            }
        }
    }
}