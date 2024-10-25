using UnityEngine;
using UnityEngine.UI;

public class ExamPrompt : MonoBehaviour
{
    public GameObject promptPanel;  // Reference to the prompt UI panel
    public GameObject examUI;  // Reference to the exam UI panel
    public GameObject endExamPanel;

    private void Start()
    {
        // Initially hide the exam prompt and UI
        promptPanel.SetActive(true);
        examUI.SetActive(false);
    }

    // Called when the player selects "Yes" to start the exam
    public void OnYesClicked()
    {
        // Enable the exam UI without teleporting the player
        examUI.SetActive(true);

        // Hide the prompt panel
        promptPanel.SetActive(false);
    }

    public void CloseEndExamPanel()
    {
        examUI.SetActive(false);            // Hide the entire Exam UI
        endExamPanel.SetActive(false);      // Ensure the EndExam Panel is hidden
        promptPanel.SetActive(true);    // Show the Exam Prompt panel
    }
}
