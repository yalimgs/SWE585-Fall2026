using UnityEngine;

// drops many cubes with rigidbody to test physics cost
public class CubeSpawner : MonoBehaviour
{
    public int cubeCount = 1000;          // how many cubes
    public bool useMeshCollider = false;  // false = box collider
    public float fixedTimestep = 0.02f;   // physics step in seconds
    public float spacing = 1.5f;          // distance between cubes (m)
    public float startHeight = 5f;        // first layer height (m)
    public int randomSeed = 42;           // same rotations every run

    void Start()
    {
        Time.fixedDeltaTime = fixedTimestep;
        Random.InitState(randomSeed);

        int perRow = 20;               // 20 x 20 cubes in one layer
        int perLayer = perRow * perRow;
        float half = (perRow - 1) * spacing / 2f;

        for (int i = 0; i < cubeCount; i++)
        {
            // grid position so cubes dont start inside each other
            float x = (i % perRow) * spacing - half;
            float z = ((i / perRow) % perRow) * spacing - half;
            float y = startHeight + (i / perLayer) * spacing;

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.name = "Cube_" + i;
            cube.transform.parent = transform;
            cube.transform.position = new Vector3(x, y, z);
            cube.transform.rotation = Random.rotation; // so they tumble

            if (useMeshCollider)
            {
                DestroyImmediate(cube.GetComponent<BoxCollider>());
                MeshCollider mc = cube.AddComponent<MeshCollider>();
                mc.convex = true; // rigidbody needs convex mesh
            }

            cube.AddComponent<Rigidbody>();
        }

        Debug.Log("spawned " + cubeCount + " cubes, mesh collider: " + useMeshCollider + ", fixed step: " + fixedTimestep);
    }
}
