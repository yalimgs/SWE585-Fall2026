using UnityEngine;

// draws the guard's view area on the floor, same size as what the guard can really see
public class VisionCone : MonoBehaviour
{
    public int segments = 20; // more pieces = smoother round edge

    void Start()
    {
        // read the view values from the guard this cone belongs to
        Guard guard = GetComponentInParent<Guard>();
        float distance = guard.viewDistance;
        float angle = guard.viewAngle;

        // the corner points of the fan shape
        Vector3[] points = new Vector3[segments + 2];
        points[0] = Vector3.zero; // tip of the fan is at the guard

        for (int i = 0; i <= segments; i++)
        {
            // go from the left edge (-angle) to the right edge (+angle)
            float a = Mathf.Lerp(-angle, angle, (float)i / segments) * Mathf.Deg2Rad;
            points[i + 1] = new Vector3(Mathf.Sin(a), 0f, Mathf.Cos(a)) * distance;
        }

        // connect the points into small triangles, like slices of a pizza
        int[] triangles = new int[segments * 3];
        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        // make the shape and show it
        Mesh mesh = new Mesh();
        mesh.vertices = points;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }
}