using UnityEngine;

public class FireballDamage : MonoBehaviour
{
    public float damageAmount = 25f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<TargetDummyHealth>(out var dummy))
        {
            dummy.TakeDamage(damageAmount);
        }

        // Destroy the fireball after impact
        Destroy(gameObject);
    }
}
