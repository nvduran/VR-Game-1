using UnityEngine;
using TMPro;

public enum PlatformType
{
    Class,
    Spell
}

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI floatingText;
    [SerializeField] private string message = "";
    [SerializeField] private string targetTag1 = "PlayerClass";
    [SerializeField] private string targetTag2 = "ClassSpell";
    [SerializeField] private PlatformType platformType;

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.CompareTag(targetTag1) || other.CompareTag(targetTag2))) return;

        string firstWord = other.gameObject.name.Split(' ')[0];
        floatingText.text = string.IsNullOrEmpty(message) ? firstWord : message;

        if (GameHomeManager.Instance != null)
        {
            switch (platformType)
            {
                case PlatformType.Class:
                    GameHomeManager.Instance.SetSelectedClass(firstWord);
                    floatingText.text = firstWord;
                    break;
                case PlatformType.Spell:
                    GameHomeManager.Instance.SetSelectedSpell1(firstWord);
                    floatingText.text = firstWord;
                    break;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(targetTag1) || !other.CompareTag(targetTag2))
        {
            floatingText.text = "";
        }
    }
}
