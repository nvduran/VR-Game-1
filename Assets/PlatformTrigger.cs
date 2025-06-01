using UnityEngine;
using TMPro;

public class PlatformTrigger : MonoBehaviour
{
    public TextMeshProUGUI floatingText; // Drag your floating text here in the Inspector
    public string message = "Cube placed!";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerCube"))
        {
            string fullName = other.gameObject.name;
            string firstWord = fullName.Split(' ')[0]; // Gets "mage" from "mage class selection cylinder"
            floatingText.text = firstWord;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerClass"))
        {
            floatingText.text = ""; // Clear the message when cube leaves
        }
    }
}
