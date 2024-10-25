using UnityEngine;

[System.Serializable]
public class ExamQuestion
{
    public GameObject questionObject; // The object or image related to the question
    public string[] possibleAnswers;  // The 4 answer options
    public string correctAnswer;      // The correct answer
}
