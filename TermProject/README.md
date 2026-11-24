# SWE 585 Term Project – Option A (Single Challenge)

**Topic:** Performance cost of large numbers of physics objects (Rigidbody) in Unity

**Student:** Yalım Özçağlayan – 2025719117  
**Unity Version:** 6000.3.26f1 (URP)

## Road Map

<table>
  <tr><th>Week</th><th>Work</th><th>Status</th></tr>
  <tr><td>18.11 – 24.11</td><td>Build the test scene, spawner script and FPS counter</td><td>Done</td></tr>
  <tr><td>25.11 – 01.12</td><td>Run experiments for all parameters, collect profiler data</td><td>Next</td></tr>
  <tr><td>02.12 – 08.12</td><td>Apply optimizations and measure again, compare results</td><td>Planned</td></tr>
  <tr><td>09.12 – 12.12</td><td>Prepare graphs, write final report, record short video</td><td>Planned</td></tr>
</table>

## Week 1 – Test Scene

**Scene:** `Assets/Scenes/PhysicsTest.unity`

- Flat ground (50 m x 50 m) with 4 walls so cubes stay inside
- `Spawner` object with `CubeSpawner.cs`: drops N cubes with Rigidbody in a 20 x 20 grid, layer by layer
- `FpsCounter.cs`: shows FPS and frame time (ms) on screen
- Same camera, light and random seed in every run → repeatable

**Parameters (set in the Inspector on `Spawner`):**

- `cubeCount` – object count (100 / 500 / 1000 / 2500 / 5000)
- `useMeshCollider` – Box Collider vs Mesh Collider (convex)
- `fixedTimestep` – physics step (0.02 / 0.01 / 0.005 s)

**How to run:** open the scene, select `Spawner`, set the parameters, press Play. Open *Window → Analysis → Profiler* to see the Physics time on the CPU.
