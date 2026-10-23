# SWE 585 – In Class Practice #2: Collision Detection and Tunneling

**Date:** 14.10.2026  **Unity:** 6000.3.26f1  **Scene:** `Assets/Scenes/TestScene.unity`

## Goal
Observe the tunneling effect (a fast ball passing through a thin wall) in Unity's
discrete collision detection, find the parameters that affect it, and test them.

## What was done
- **Step 2:** Ran TestScene. With the default settings (Direction X = −5) all 3 balls hit the brick wall and stopped – no tunneling.
- **Step 3a – Parameters found:** Barrier Thickness, Ball Speed (Push Force), Fixed Timestep, Collision Detection Mode, Ball Size, Ball Mass, Linear Damping (Drag), Distance to the Wall, Friction (Physics Material).
- **Step 3b – Quick tests:**
  - Ball Speed: no tunneling at −5 and −10, 2 balls passed at −15.
  - Barrier Thickness (at −15): 2 balls passed at 0.02 and 0.5, none at 1.
  - Fixed Timestep (at −15): no tunneling at 0.01; at 0.1 the balls went into the wall and came back out.
- **Step 4 – Experiments (Discrete mode, 10 runs each):** Ball Speed (Direction X) vs. Barrier Thickness (Scale X)

  | Speed | Thickness | Tunneling |
  |---|---|---|
  | −10 | 0.02 / 0.05 / 1 | 0/10 |
  | −15 | 0.02 / 0.05 | 10/10 (balls 1 & 3) |
  | −20 | 0.02 / 0.05 | 10/10 (ball 3) |
  | −15, −20 | 1 | 0/10 |

- **Step 5 – Result:** Tunneling happens when the ball is fast and the wall is thin. A thick wall (1) stopped it at every speed. Which ball tunnels depends on where it is at each physics step, so it is not only about speed. Results were the same in all 10 runs because Unity physics is repeatable with the same settings.
- **Step 6 (Bonus):** Added the tag `Barrier` to the Brick Wall and `OnCollisionEnter()` to `Assets/Scripts/BallBooster.cs`. When a ball hits the wall for the first time, it becomes 1.5× bigger and turns red.

## How to run
Open this folder in Unity Hub, open `TestScene`, press Play. Change **Direction** on the `Roller` prefab (Ball Booster) and **Scale X** of `Brick Wall` to repeat the experiments. Use **Reset All** to restart a run.
