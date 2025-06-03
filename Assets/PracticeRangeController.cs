using UnityEngine;
using TMPro;

public class PracticeRangeController : MonoBehaviour
{
    public TextMeshProUGUI classNameText; // Assign this in the Inspector
    public TextMeshProUGUI spellNameText; // Assign this in the Inspector

    public string defaultMessage = "Cube placed!";

    void Start()
    {
        string className = GameHomeManager.Instance.selectedClassName;
        string classSpellName = GameHomeManager.Instance.selectedSpell1;

        Debug.Log("Loaded class: " + className);
        Debug.Log("Loaded spell: " + classSpellName);

        if (!string.IsNullOrEmpty(className))
        {
            classNameText.text = className;
        }

        if (!string.IsNullOrEmpty(classSpellName))
        {
            spellNameText.text = classSpellName;
        }

        // Optionally destroy GameHomeManager
        Destroy(GameHomeManager.Instance.gameObject);
    }
}
