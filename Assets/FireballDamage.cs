using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public float damageAmount = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        // Check for TargetDummyHealth
        if (collision.gameObject.TryGetComponent<TargetDummyHealth>(out var dummy))
        {
            dummy.TakeDamage(damageAmount);
            // Destroy the fireball after impact
            Destroy(gameObject);
        }
        
        // Check for PlayerHealth
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out var player))
        {
            player.TakeDamage(damageAmount);
            // Destroy the fireball after impact
            Destroy(gameObject);
        }

        
    }
}