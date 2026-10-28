using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// controls the end of the game: shows the win / lose screen with two buttons
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // other scripts reach this with GameManager.instance

    public GameObject endPanel; // the dark screen with the message and buttons
    public TMP_Text endText;    // the big message on that screen

    bool gameOver = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;                      // make sure the game runs at normal speed
        endPanel.SetActive(false);                // hide the end screen at the start
        Cursor.lockState = CursorLockMode.Locked; // hide the mouse while playing
        Cursor.visible = false;
    }

    public void Win()
    {
        EndGame("You escaped! You win!");
    }

    public void Lose(string reason)
    {
        EndGame(reason);
    }

    void EndGame(string message)
    {
        if (gameOver) return; // the game can only end once
        gameOver = true;

        endText.text = message + "\nPlay another round?";
        endPanel.SetActive(true);

        Time.timeScale = 0f; // freeze everything: guards, traps, timers

        // stop the player and the camera from moving
        GameObject player = GameObject.FindWithTag("Player");
        ((Behaviour)player.GetComponent("ThirdPersonController")).enabled = false;

        // show the mouse so the buttons can be clicked
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // called by the "Play Again" button
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // called by the "Quit" button
    public void Quit()
    {
        Application.Quit(); // closes the game when it is built
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // stops play mode inside the editor
#endif
    }
}