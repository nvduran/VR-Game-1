using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class TargetDummyHealth : MonoBehaviour
{
    public Image healthBarFill;
    public float maxHealth = 100f;
    private float currentHealth;

    private Vector3 spawnPosition;
    private Quaternion spawnRotation;

    public TargetDummyManager manager; // assign this in the inspector

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        spawnPosition = transform.position;
        spawnRotation = transform.rotation;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0f)
        {
            Debug.Log("Target Dummy defeated!");
            manager.RespawnDummyAfterDelay(this, 3f);
            gameObject.SetActive(false);
        }
    }

    public void ResetDummy()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
        transform.position = spawnPosition;
        transform.rotation = spawnRotation;
        gameObject.SetActive(true);
    }

    private void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = currentHealth / maxHealth;
        }
    }
}
