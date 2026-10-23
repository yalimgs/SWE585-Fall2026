# SWE 585 In Class Practice #2 – Collision Detection and Tunneling

**Date:** 14.10.2026  
**Name, Surname:** Yalım Özçağlayan  
**Scene:** `Assets/Scenes/TestScene.unity`

---

### STEP 1
*Provide your system summary below.*

| Component | Value |
|---|---|
| Operating System | Windows 11 Pro |
| CPU | AMD Ryzen 9 7900X3D (12 cores / 24 threads) |
| RAM | 64 GB DDR5-6000 |
| Unity Version | 6000.3.26f1 |

### STEP 2
*Open the scene and run the game. You should see the tunneling effect in action.*

I opened TestScene and ran the game. All three balls hit the brick wall and stopped. I did not see tunneling with the default settings.

### STEP 3a
*Discuss as a group what parameters are effective on the Tunneling Phenomenon. Try to identify them. (Barrier thickness is one of them, what about the others?) Note that these parameters must be changeable by Unity Editor menus and/or C# scripts. Make a list of all such parameters below.*

| # | Parameter |
|---|---|
| Parameter #1 | Barrier Thickness |
| Parameter #2 | Ball Speed (Push Force) |
| Parameter #3 | Fixed Timestep |
| Parameter #4 | Collision Detection Mode |
| Parameter #5 | Ball Size |
| Parameter #6 | Ball Mass |
| Parameter #7 | Linear Damping (Drag) |
| Parameter #8 | Distance to the Wall |
| Parameter #9 | Friction (Physics Material) |

### STEP 3b
*Feel free to play with some of it and see if tunneling stays or disappears.*

- **Ball Speed:** With the default push force (Direction X = −5), no ball passed through the wall. When I increased it to −15, 2 of the 3 balls passed through the wall. (At −10 there was still no tunneling.)
- **Barrier Thickness:** At 0.02 and 0.5, 2 balls passed through. At 1, no ball passed. A thicker wall stops tunneling. (with Direction X = −15)
- **Fixed Timestep:** At 0.01, all 3 balls stopped. No tunneling.
- **Fixed Timestep:** At 0.1, the balls went into the wall and then came back out.

### STEP 4
*Design a series of Collision Detection experiments. In these experiments collision detection mode should be discrete. First choose just two of the parameters you identified. Run some experiments with different values and report their results. Repeat each experiment instance 10 times and summarize the result using the notation 3/10 (tunneling observed 3 out of 10 runs).*

| # | Parameter |
|---|---|
| Parameter Chosen 1 | Ball Speed (Direction X) |
| Parameter Chosen 2 | Barrier Thickness (Scale X) |

| Ball Speed (Direction X) | Barrier Thickness (Scale X) | Tunneling observed? | Comments |
|---|---|---|---|
| −10 | 0.02 | 0/10 | |
| −10 | 0.05 | 0/10 | |
| −10 | 1 | 0/10 | |
| −15 | 0.02 | 10/10 | 2 balls passed through (1st & 3rd) |
| −15 | 0.05 | 10/10 | 2 balls passed through (1st & 3rd) |
| −15 | 1 | 0/10 | |
| −20 | 0.02 | 10/10 | 3rd ball passed through |
| −20 | 0.05 | 10/10 | 3rd ball passed through |
| −20 | 1 | 0/10 | |

### STEP 5
*Collaboratively discuss and comment on the above results as a group.*

At speed −10, no ball passed through the wall with any thickness. The balls were too slow, so even the thinnest wall was enough to stop them.

At −15 and −20, the balls passed through the 0.02 and 0.05 walls. There was no difference between these two thicknesses, because the walls are still very thin compared to the ball (diameter 1).

When the thickness was 1, no ball passed through at any speed. A thick enough wall stops tunneling.

At −20 only 1 ball passed, but at −15 two balls passed. With discrete detection, Unity checks the ball position only at each physics step. If the ball is in the back half of the wall at that moment, it is pushed through. So which ball tunnels depends on timing and the start position, not only on speed.

Every setting gave the same result in all 10 runs (0/10 or 10/10), because Unity physics gives the same result each time with the same settings.

Conclusion: tunneling happens when the ball is fast and the wall is thin. Making the wall thicker (or using Continuous collision detection) solves it.

### STEP 6 (Bonus)
*Modify the necessary script so that if a ball hits the first barrier a visual action is taken, e.g. change size of the ball. Hint: Check out OnCollisionEnter(). You may need to tag the barrier in order to understand which object the ball has collided.*

The Brick Wall was given the tag `Barrier`, and `OnCollisionEnter()` was added to `Assets/Scripts/BallBooster.cs`. When a ball hits the wall for the first time, it becomes 1.5 times bigger and turns red.

```csharp
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
```
