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

    // right click the component and choose "Build Maze"
    [ContextMenu("Build Maze")]
    void BuildMaze()
    {
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
                    wall.transform.position = new Vector3(col * size, size / 2f, -row * size);
                    wall.transform.localScale = new Vector3(size, size, size);
                    wall.transform.parent = transform; // keep walls under the maze object
                }
            }
        }
    }
}