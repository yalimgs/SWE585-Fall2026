using UnityEngine;

// draws the guard's view area on the floor and cuts it where a wall is in the way
public class VisionCone : MonoBehaviour
{
    public int segments = 30; // more pieces = smoother edge

    Guard guard;
    Mesh mesh;
    Vector3[] points;

    void Start()
    {
        guard = GetComponentInParent<Guard>(); // the guard this cone belongs to
        points = new Vector3[segments + 2];

        // connect the points into small triangles, like slices of a pizza
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh = new Mesh();
        mesh.vertices = points;
        mesh.triangles = triangles;
        GetComponent<MeshFilter>().mesh = mesh;
    }

    // runs every frame, after the guard has moved
    void LateUpdate()
    {
        points[0] = Vector3.zero; // tip of the fan is at the guard

        for (int i = 0; i <= segments; i++)
        {
            // angle of this slice, from the left edge to the right edge
            float a = Mathf.Lerp(-guard.viewAngle, guard.viewAngle, (float)i / segments);

            // direction of this slice: in the guard's own space and in the world
            Vector3 localDir = Quaternion.Euler(0f, a, 0f) * Vector3.forward;
            Vector3 worldDir = guard.transform.TransformDirection(localDir);

            // shoot a ray from the guard, if it hits a wall the slice stops there
            float length = guard.viewDistance;
            RaycastHit hit;
            if (Physics.Raycast(guard.transform.position, worldDir, out hit, guard.viewDistance, ~0, QueryTriggerInteraction.Ignore)
                && !hit.transform.CompareTag("Player"))
            {
                length = hit.distance;
            }

            points[i + 1] = localDir * length;
        }

        // update the shape on screen
        mesh.vertices = points;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}