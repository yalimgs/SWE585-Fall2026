# SWE 585 In Class Practice #1 – Warming Up

**Date:** 07.10.2026
**Group #:** 1
**Group Members:** Yalım Özçağlayan, Oğuz Beren Özşahin, Batu Demir

---

### STEP 1
*Provide your system summary below.*

| System Summary | |
|---|---|
| Operating System | Windows 11 Enterprise 25H2 |
| CPU | 13th Gen Intel Core i7-1370P (1.90 GHz) |
| RAM | 16 GB 5200 MT/s |
| Unity Version | Unity 6.3 LTS (6000.3.25f1) |

### STEP 2
*Create a ball that perpetually bounces on a platform. (Ball should keep the same height at each bounce)*
*(Hint: You will not need to write any code for this ICP. You will need to create a "Physics material" and assign it to your ball. Hopefully physics engine will do the rest)*

A platform and a ball were created in `Assets/Scenes/SampleScene.unity`. No code was written; the bouncing is done only with a Physics Material (`Assets/BouncyMaterial.physicMaterial`) and Rigidbody / Time settings (see Step 4).

### STEP 3
*Screenshot of the final scene.*

The final scene is `Assets/Scenes/SampleScene.unity`. Press Play to see the ball bouncing on the platform.

### STEP 4
*Explain the flow of your work (as a group). What properties of Unity you used, what parameters you changed etc. – max 200 words.*

We started by setting up the scene in Unity. First, we created a platform. We did not add a Rigidbody to the platform, so it stays fixed and is not affected by gravity. Next, we created a Sphere as the ball, placed it at a height of 10 units, and added a Rigidbody component so that gravity and collisions would act on it.

To make the ball bounce forever without writing any code, we created a Physics Material. We set its Bounciness to 1 and its Bounce Combine mode to Maximum, so the ball keeps all of its energy on every impact. We set both friction values to 0 with Friction Combine set to Minimum, so the ball loses no energy to friction or spin. We assigned this material to the ball's Sphere Collider. We set the Fixed Timestep to 0.001.

Finally, we set the Rigidbody's Linear and Angular Damping to 0 to remove air resistance. When we tested the scene in Play mode, the ball bounced back to almost the same height every time.
