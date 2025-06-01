using UnityEngine;
using TMPro;

public class PlayerModeTrigger : MonoBehaviour
{
    public TextMeshProUGUI floatingText; // Assign in Inspector
    public string message = "Practice Mode Selected";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Good — make sure your player GameObject has this tag
        {
            floatingText.text = message;

            // Notify GameHomeManager
            if (GameHomeManager.Instance != null)
            {
                GameHomeManager.Instance.OnPracticeModeSelected();
            }
            else
            {
                Debug.LogWarning("GameHomeManager not found!");
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            floatingText.text = "";
        }
    }
}
