using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHomeManager : MonoBehaviour
{
    public static GameHomeManager Instance;

    private bool classSelected = false;
    private bool practiceModeSelected = false;

    public string selectedClassName; // <-- Add this!

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // <-- Persist this object across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetSelectedClass(string className)
    {
        selectedClassName = className;
        classSelected = true;
        CheckStartPracticeRange();
    }

    public void OnPracticeModeSelected()
    {
        practiceModeSelected = true;
        CheckStartPracticeRange();
    }

    private void CheckStartPracticeRange()
    {
        if (classSelected && practiceModeSelected)
        {
            SceneManager.LoadScene("PracticeRangeScene");
        }
    }
}
