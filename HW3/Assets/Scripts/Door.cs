using UnityEngine;

// opens the door when the key hits it and the player wins
public class Door : MonoBehaviour
{
    // unity calls this by itself when something hits the door
    void OnCollisionEnter(Collision collision)
    {
        // only the key can open the door
        if (collision.gameObject.name == "Key")
        {
            gameObject.SetActive(false); // hide the door so it looks open
            GameManager.instance.Win();  // show the win screen
        }
    }
}