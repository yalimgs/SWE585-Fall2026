using UnityEngine;

// builds the maze from a text map
public class MazeBuilder : MonoBehaviour
{
    // the maze drawn with letters, north is up
    // '#' = wall, ' ' = path, 'D' = door
    string[] map =
    {
        "###############",
        "#             D",
        "#   ### ### ###",
        "#   #     #   #",
        "##### ### # # #",
        "#     #   # # #",
        "# ### # ### # #",
        "# #   # #   # #",
        "# ### # # # # #",
        "#   #   # #   #",
        "### # ##### # #",
        "#   #     #   #",
        "# ####### # # #",
        "#           # #",
        "###############"
    };
        // size of one letter in metres (1 unity unit = 1 m)
    public float size = 3f;
    public Material outerWallMaterial; // dark color for the outside walls
    public Material innerWallMaterial; // light color for the walls inside

    // right click the component and choose "Build Maze"
    [ContextMenu("Build Maze")]
    void BuildMaze()
    {
        // delete the old walls first so they don't pile up
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (child.name == "Wall" || child.name == "Cube") DestroyImmediate(child);
        }
        // go through every row of the map
        for (int row = 0; row < map.Length; row++)
        {
            // go through every letter in that row
            for (int col = 0; col < map[row].Length; col++)
            {
                // if the letter is a wall, make a cube there
                if (map[row][col] == '#')
                {
                    GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    wall.transform.parent = transform; // keep walls under the maze object

                    // shift everything by half the maze so the centre of the maze is the maze object
                    float half = (map.Length - 1) * size / 2f;
                    wall.transform.localPosition = new Vector3(col * size - half, size / 2f, -row * size + half);
                    wall.transform.localScale = new Vector3(size, size, size);
                                        wall.name = "Wall";
                    // walls on the edge of the map are outer walls
                    bool isOuter = row == 0 || row == map.Length - 1 || col == 0 || col == map[row].Length - 1;
                    if (isOuter) wall.GetComponent<Renderer>().sharedMaterial = outerWallMaterial;
                    else wall.GetComponent<Renderer>().sharedMaterial = innerWallMaterial;
                }
            }
        }
    }
}