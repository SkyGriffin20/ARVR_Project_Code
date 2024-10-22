using UnityEngine;
using TMPro; // For TextMeshPro
using UnityEngine.XR.Interaction.Toolkit; // For XR interaction

public class DisplayObjectName : MonoBehaviour
{
    public string objectName;  // The French name of the object
    public TextMeshProUGUI nameDisplay;  // Reference to the TextMeshPro UI element
    private XRGrabInteractable grabInteractable;  // Reference to the XR grab interactable

    void Start()
    {
        if (name != null)
        {
            nameDisplay.text = "";
        }
    }

    private void Awake()
    {
        // Get the XRGrabInteractable component from the object
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Register the OnGrab and OnRelease methods to the events
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    // Method that triggers when the object is grabbed
    private void OnGrab(SelectEnterEventArgs args)
    {
        Debug.Log("Object grabbed: " + objectName);  // Log for debugging
        if (nameDisplay != null)
        {
            nameDisplay.text = objectName;  // Set the UI text to the object's name
        }
    }

    // Method that triggers when the object is released
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released: " + objectName);  // Log for debugging
        if (nameDisplay != null)
        {
            nameDisplay.text = "";  // Clear the UI text
        }
    }

    private void OnDestroy()
    {
        // Unregister the event listeners when the object is destroyed
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
