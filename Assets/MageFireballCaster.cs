using UnityEngine;
using UnityEngine.InputSystem;

public class MageFireballCaster : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionReference gripActionReference;
    public InputActionReference triggerActionReference;

    [Header("Fireball Settings")]
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;

    private bool isCasting = false;
    private float gripHoldTime = 0f;
    private bool gripHeld = false;

    private void OnEnable()
    {
        if (gripActionReference != null)
        {
            gripActionReference.action.Enable();
            gripActionReference.action.performed += OnGripPerformed;
            gripActionReference.action.canceled += OnGripCanceled;
        }

        if (triggerActionReference != null)
        {
            triggerActionReference.action.Enable();
            triggerActionReference.action.performed += OnTriggerPerformed;
        }
    }

    private void OnDisable()
    {
        if (gripActionReference != null)
        {
            gripActionReference.action.performed -= OnGripPerformed;
            gripActionReference.action.canceled -= OnGripCanceled;
            gripActionReference.action.Disable();
        }

        if (triggerActionReference != null)
        {
            triggerActionReference.action.performed -= OnTriggerPerformed;
            triggerActionReference.action.Disable();
        }
    }

    private void Update()
    {
        if (gripHeld && !isCasting)
        {
            gripHoldTime += Time.deltaTime;
            if (gripHoldTime >= 1f)
            {
                isCasting = true;
                Debug.Log("Ready to cast fireball!");
            }
        }
    }

    private void OnGripPerformed(InputAction.CallbackContext context)
    {
        gripHeld = true;
        // Reset hold time on new grip press
        gripHoldTime = 0f;
    }

    private void OnGripCanceled(InputAction.CallbackContext context)
    {
        gripHeld = false;
        gripHoldTime = 0f;
        isCasting = false;
    }

    private void OnTriggerPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Trigger pressed!");
        if (isCasting)
        {
            FireFireball();
            isCasting = false;
            gripHoldTime = 0f;
            gripHeld = false;
        }
    }

    private void FireFireball()
    {
        Debug.Log("FireFireball() called");

        if (fireballPrefab == null)
        {
            Debug.LogWarning("fireballPrefab is NULL!");
            return;
        }

        if (fireballSpawnPoint == null)
        {
            Debug.LogWarning("fireballSpawnPoint is NULL!");
            return;
        }

        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, fireballSpawnPoint.rotation);
        Debug.Log("Fireball instantiated at: " + fireballSpawnPoint.position);

        if (fireball.TryGetComponent<Rigidbody>(out var rb))
        {
            rb.linearVelocity = fireballSpawnPoint.forward * 10f;
            Debug.Log("Fireball velocity set");
        }
        else
        {
            Debug.LogWarning("Fireball has no Rigidbody!");
        }

        Debug.Log("Fireball launched!");
    }
}
