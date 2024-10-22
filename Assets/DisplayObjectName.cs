using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisplayObjectName : MonoBehaviour
{
    public string objectName;  // The French name of the object
    private XRGrabInteractable grabInteractable;  // Reference to the XR grab interactable

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

        // Use the UIManager to display the object's name
        if (UIManager.Instance != null)
        {
            UIManager.Instance.DisplayObjectName(objectName);
        }
    }

    // Method that triggers when the object is released
    private void OnRelease(SelectExitEventArgs args)
    {
        Debug.Log("Object released: " + objectName);  // Log for debugging

        // Use the UIManager to clear the displayed name
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ClearObjectName();
        }
    }

    private void OnDestroy()
    {
        // Unregister the event listeners when the object is destroyed
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }
}
