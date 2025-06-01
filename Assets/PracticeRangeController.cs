using UnityEngine;
using TMPro;

public class PracticeRangeController : MonoBehaviour
{
    public TextMeshProUGUI floatingText; // Assign this in the Inspector
    public string message = "Cube placed!";

    void Start()
    {
        string className = GameHomeManager.Instance.selectedClassName;
        Debug.Log("Loaded class: " + className);

        if(className != null)
        {
            floatingText.text = className;
        } 

        

        // You can now use className to configure the scene

        // Optionally destroy GameHomeManager
        Destroy(GameHomeManager.Instance.gameObject);
    }
}