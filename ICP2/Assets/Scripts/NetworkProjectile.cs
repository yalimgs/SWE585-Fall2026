using System.Collections;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public sealed class NetworkProjectile : NetworkBehaviour
{
    [SerializeField] private float speed = 9f;
    [SerializeField] private float lifetime = 3f;

    private bool hasHit;

    public override void OnStartServer()
    {
        GetComponent<Rigidbody>().linearVelocity = transform.forward * speed;
        StartCoroutine(DestroyAfterLifetime());
    }

    [ServerCallback]
    private void OnCollisionEnter(Collision collision)
    {
        // only hit once
        if (hasHit)
            return;
        hasHit = true;

        if (collision.gameObject.TryGetComponent(out NetworkPlayerHealth health))
            health.TakeDamage(1);

        NetworkServer.Destroy(gameObject);
    }

    [Server]
    private IEnumerator DestroyAfterLifetime()
    {
        yield return new WaitForSeconds(lifetime);
        if (!hasHit)
            NetworkServer.Destroy(gameObject);
    }
}