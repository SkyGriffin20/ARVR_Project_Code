using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class nameDisplay : MonoBehaviour
{
    public string objectName;  
    public TextMeshProUGUI name;

    // Start is called before the first frame update
    void Start()
    {
        if (name != null)
        {
            name.text = "";
        }
    }

    public void OnSelectEnter(SelectEnterEventArgs args)
    {
        Debug.Log("Select");
        if (name != null)
        {
            name.text = objectName;
        }
    }

    // Called when the object is released
    public void OnSelectExit(SelectExitEventArgs args)
    {
        if (name != null)
        {
            name.text = "";
        }
    }
}
