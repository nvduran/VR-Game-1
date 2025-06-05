using UnityEngine;

public class TargetDummyGun : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float shootInterval = 2f;
    public float projectileSpeed = 1f;

    private float shootTimer = 0f;

    void Update()
    {
        shootTimer += Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            FireFireball();
            shootTimer = 0f;
        }
    }

    private void FireFireball()
    {
        if (fireballPrefab == null || fireballSpawnPoint == null)
        {
            Debug.LogWarning("Fireball prefab or spawn point is not set!");
            return;
        }

        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
        if (fireball.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.linearVelocity = fireballSpawnPoint.forward * projectileSpeed;
        }
    }
}
