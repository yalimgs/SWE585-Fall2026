using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

// controls pausing and the end of the game
public class GameManager : MonoBehaviour
{
    public static GameManager instance; // other scripts reach this with GameManager.instance

    public GameObject endPanel;   // the win / lose screen
    public TMP_Text endText;      // the big message on that screen
    public GameObject pausePanel; // the pause screen

    bool gameOver = false;
    bool paused = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
        SetPlayerControl(true);
    }

    void Update()
    {
        // esc opens and closes the pause screen (not after the game is over)
        if (Keyboard.current.escapeKey.wasPressedThisFrame && !gameOver)
        {
            if (paused) Resume();
            else Pause();
        }
    }

    void Pause()
    {
        paused = true;
        pausePanel.SetActive(true);
        Time.timeScale = 0f;     // freeze the game
        SetPlayerControl(false);
    }

    // called by the "Resume" button and by esc
    public void Resume()
    {
        paused = false;
        pausePanel.SetActive(false);
        Time.timeScale = 1f;     // run the game again
        SetPlayerControl(true);
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
        Time.timeScale = 0f;
        SetPlayerControl(false);
    }

    // turns the player controls and the hidden mouse on or off
    void SetPlayerControl(bool on)
    {
        GameObject player = GameObject.FindWithTag("Player");
        ((Behaviour)player.GetComponent("ThirdPersonController")).enabled = on;

        if (on) Cursor.lockState = CursorLockMode.Locked; // hide the mouse while playing
        else Cursor.lockState = CursorLockMode.None;      // show the mouse for the buttons
        Cursor.visible = !on;
    }

    // called by the "Play Again" button
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // called by the "Quit" buttons
    public void Quit()
    {
        Application.Quit(); // closes the game when it is built
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // stops play mode inside the editor
#endif
    }
}