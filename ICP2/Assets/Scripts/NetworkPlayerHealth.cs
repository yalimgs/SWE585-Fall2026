using System.Collections;
using Mirror;
using UnityEngine;

public sealed class NetworkPlayerHealth : NetworkBehaviour
{
    [SyncVar]
    [SerializeField] private int health = 3;

    [SyncVar]
    private bool isDefeated;

    public int Health => health;
    public bool IsDefeated => isDefeated;

    [Server]
    public void TakeDamage(int amount)
    {
        // no damage while dead
        if (isDefeated || health <= 0)
            return;

        health = Mathf.Max(0, health - amount);
        if (health == 0)
            StartCoroutine(RespawnAfterDelay());
    }

    [Server]
    private IEnumerator RespawnAfterDelay()
    {
        isDefeated = true;
        RpcSetVisible(false);

        yield return new WaitForSeconds(2f);

        // pick a spawn point
        Transform start = NetworkManager.singleton.GetStartPosition();
        Vector3 position = start != null ? start.position : Vector3.up;
        Quaternion rotation = start != null ? start.rotation : Quaternion.identity;

        // move on server, then tell the owner
        transform.SetPositionAndRotation(position, rotation);
        TargetApplyRespawn(connectionToClient, position, rotation);

        health = 3;
        isDefeated = false;
        RpcSetVisible(true);
    }

    [TargetRpc]
    private void TargetApplyRespawn(NetworkConnectionToClient target,
        Vector3 position, Quaternion rotation)
    {
        transform.SetPositionAndRotation(position, rotation);
        GetComponent<NetworkTransformReliable>().ResetState();
    }

    [ClientRpc]
    private void RpcSetVisible(bool visible)
    {
        // hide or show the player on all clients
        foreach (Renderer r in GetComponentsInChildren<Renderer>())
            r.enabled = visible;
        foreach (Collider c in GetComponentsInChildren<Collider>())
            c.enabled = visible;
    }

    private void OnGUI()
    {
        // show my health and the other player's health
        GUIStyle style = new GUIStyle(GUI.skin.label) { fontSize = 22 };
        float y = isLocalPlayer ? Screen.height - 70 : Screen.height - 40;
        string who = isLocalPlayer ? "My health: " : "Enemy health: ";
        GUI.Label(new Rect(10, y, 300, 30), who + health, style);
    }
}