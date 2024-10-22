using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;  // Singleton instance
    public TextMeshProUGUI nameDisplay;  // Reference to the UI text element to display the name

    private void Awake()
    {
        // Ensure there is only one instance of the UIManager (Singleton pattern)
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to update the UI with the object's name
    public void DisplayObjectName(string objectName)
    {
        if (nameDisplay != null)
        {
            nameDisplay.text = objectName;
        }
    }

    // Method to clear the object name from the UI
    public void ClearObjectName()
    {
        if (nameDisplay != null)
        {
            nameDisplay.text = "";
        }
    }
}
