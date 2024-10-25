using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExamManager : MonoBehaviour
{
    public GameObject[] questionPanels;  // Array to store each question panel
    public TextMeshProUGUI resultText;   // Text to show feedback (Correct/Wrong)
    public int playerEXP = 0;            // Player's experience points
    public GameObject endExamPanel;           // Reference to the EndExam Panel
    public TextMeshProUGUI endExamMessage;

    private int currentQuestionIndex = 0;

    void Start()
    {
        // Hide all question panels initially
        foreach (var panel in questionPanels)
        {
            panel.SetActive(false);
        }

        // Start the exam with the first question
        DisplayCurrentQuestion();
        resultText.text = "";  // Clear result text at the beginning
    }

    void DisplayCurrentQuestion()
    {
        // Hide all question panels, then show the current one
        foreach (var panel in questionPanels)
        {
            panel.SetActive(false);
        }

        // Show the current question panel
        if (currentQuestionIndex < questionPanels.Length)
        {
            questionPanels[currentQuestionIndex].SetActive(true);
        }
        else
        {
            EndExam();  // If no more questions, end the exam
        }
    }

    // Function to handle the correct answer
    public void HandleCorrectAnswer()
    {
        resultText.text = "Correct!";
        playerEXP += 10;  // Increase player EXP for correct answer
        DisableAnswerButtons();  // Disable all buttons for the current question
        StartCoroutine(WaitAndNextQuestion());
    }

    // Function to handle the wrong answer
    public void HandleWrongAnswer()
    {
        resultText.text = "Wrong!";
        DisableAnswerButtons();  // Disable all buttons for the current question
        StartCoroutine(WaitAndNextQuestion());
    }

    // Function to disable all answer buttons for the current question
    void DisableAnswerButtons()
    {
        var buttons = questionPanels[currentQuestionIndex].GetComponentsInChildren<Button>();
        foreach (var button in buttons)
        {
            button.interactable = false;  // Make the button unpressable
        }
    }

    // Coroutine to wait and then move to the next question
    IEnumerator WaitAndNextQuestion()
    {
        yield return new WaitForSeconds(2);  // Wait 

        resultText.text = "";  // Clear the result text
        currentQuestionIndex++;  // Move to the next question
        DisplayCurrentQuestion();
    }

    void EndExam()
    {
        // Display the end exam message and player EXP
        endExamMessage.text = "Exam Complete! Total EXP: " + playerEXP;

        // Show the EndExamPanel and hide other panels
        endExamPanel.SetActive(true);
        foreach (var panel in questionPanels)
        {
            panel.SetActive(false);
        }
    }
}
