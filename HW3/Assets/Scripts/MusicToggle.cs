using UnityEngine;
using UnityEngine.InputSystem;

// press M to turn the background music on and off
public class MusicToggle : MonoBehaviour
{
    AudioSource music;

    void Start()
    {
        music = GetComponent<AudioSource>(); // the audio source on this object
    }

    void Update()
    {
        // check every frame if M was pressed in this frame
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            music.mute = !music.mute; // flip: on becomes off, off becomes on
        }
    }
}