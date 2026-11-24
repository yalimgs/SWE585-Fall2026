using UnityEngine;

// shows fps and frame time on screen
public class FpsCounter : MonoBehaviour
{
    float timer;
    int frames;
    float fps;

    void Update()
    {
        frames++;
        timer += Time.unscaledDeltaTime;

        // update the number twice a second
        if (timer >= 0.5f)
        {
            fps = frames / timer;
            frames = 0;
            timer = 0f;
        }
    }

    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 32;
        style.normal.textColor = Color.yellow;

        float ms = fps > 0 ? 1000f / fps : 0f;
        GUI.Label(new Rect(20, 20, 600, 50), "FPS: " + fps.ToString("F1") + "   (" + ms.ToString("F1") + " ms)", style);
    }
}
