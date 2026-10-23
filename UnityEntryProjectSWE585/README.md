# SWE 585 – Unity Entry Project

**Unity:** 6000.3.26f1  **Scene:** `Assets/Scenes/SampleScene.unity`

## Goal
Learn the basic features and workflow of Unity: object creation, transforms, rigidbodies and physics,
physics materials, materials and textures, scripting and inputs, lighting, camera, animation and sound.

## What was done
| Step | Task | How it was done |
|---|---|---|
| 2.1 | Platform | `Platform` with a kinematic Rigidbody (not affected by forces or gravity), surrounded by `Wall1–4` |
| 2.2 | Movable objects | `CubeObject` and `PLAYER` with Rigidbodies, affected by forces, collisions and gravity |
| 2.3 | Physics materials | `BouncyMaterial` physics material, tested on the `CubeSlope` slope |
| 2.4 | Collision | Movable objects are dropped on the platform and collide with it |
| 2.5 | Scripts | Scripts are in `Assets/Scripts`, all derive from `MonoBehaviour` |
| 2.6 | Forces | `ObjectController.cs` adds a constant force every physics step (Rigidbody assigned in the Inspector) |
| 2.7 | Textures | `SphereMaterial` / `PLAYERMaterial` made from image textures (`space_texture.jpg`, `New Texture.png`) |
| 2.8 | Prefabs | `SphereObject` prefab; `ObjectSpawner.cs` spawns it when **Space** is pressed |
| 2.9 | Lighting | Directional Light, Point Light and Spot Light |
| 2.10 | Camera | Camera position, rotation and field of view adjusted |
| 2.11 | Inputs | `PlayerController.cs` moves `PLAYER` with **WASD / Arrow keys** using forces |
| 2.12 | Animation | `CubeScale` animation scales the cube up and down (`CubeSlope` controller) |
| 2.13 | Sound | Audio Source plays `Warm Pulse.mp3`; `SoundController.cs` pauses/resumes it with **M** |
| 2.14 | Camera follow (optional) | Main Camera is a child of `PLAYER`, so it follows the player without a script |

## Controls
- **WASD / Arrow keys:** move the player
- **Space:** spawn a new sphere
- **M:** pause / resume the music

## How to run
Open this folder in Unity Hub, open `SampleScene` and press Play.
