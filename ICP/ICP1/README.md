# SWE 585 In Class Practice #1 – Warming Up

**Date:** 07.10.2026
**Group #:** 1
**Group Members:** Yalım Özçağlayan, Oğuz Beren Özşahin, Batu Demir

**STEP 1:** Provide your system summary below.

| System Summary | |
|---|---|
| Operating System | Windows 11 Enterprise 25H2 |
| CPU | 13th Gen Intel Core i7-1370P (1.90 GHz) |
| RAM | 16 GB 5200 MT/s |
| Unity Version | Unity 6.3 LTS (6000.3.25f1) |

**STEP 2:** Create a ball that perpetually bounces on a platform. (Ball should keep the same height at each bounce)

*(Hint: You will **not** need to write any code for this ICP. You will need to create a "Physics material" and assign it to your ball. Hopefully physics engine will do the rest)*

**STEP 3:** Paste below screenshot of your final scene.

**STEP 4:** Explain the flow of your work (as a group). What properties of unity you used, what parameters you changed etc – max 200 words.

- **Platform:** no Rigidbody, so it stays fixed.
- **Ball:** Sphere at height 10 with a Rigidbody (gravity + collisions).
- **Physics Material (on the ball's Sphere Collider):** Bounciness = 1, Bounce Combine = Maximum, Dynamic/Static Friction = 0, Friction Combine = Minimum.
- **Rigidbody:** Linear Damping = 0, Angular Damping = 0.
- **Time:** Fixed Timestep = 0.001.
- **Result:** the ball bounces back to almost the same height every time.

**What to submit:** This file. (Every member should submit)
