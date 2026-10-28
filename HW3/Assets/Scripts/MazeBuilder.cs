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
}