using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
REFERENCES:
How to Make a Quiz Game with Multiple Choices in Unity (Youtube/The Game Guy):
https://www.youtube.com/watch?v=G9QDFB2RQGA
How to Make a Quiz Game with Multiple Choices in Unity | Part 2 (Youtube/The Game Guy):
https://www.youtube.com/watch?v=POUemIGCyr0

*/

public class MCQManager : MonoBehaviour
{
    public List<MCQData> qna;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject quizScreen;
    public GameObject completionScreen;
    public GameObject incorrectMessage;
    public AudioSource incorrectAnswerSFX;

    public TextMeshProUGUI questionText;
    public TextMeshProUGUI questionNumberText;
    public int currentQuestionNumber = 1;
    private int totalQuestions;
    public bool isCompleted = false;
    private float timePenalty = 60f;

    public GameObject lift;
    Renderer rend;
    // Material array for lift:
    public Material[] optionmaterials;
    // Copy of currently used materials:
    public Material[] materials;
    public int x;

    private void Start()
    {
        // Records total number of questions for level:
        totalQuestions = qna.Count;
        completionScreen.SetActive(false);
        // Populate the terminal MCQ interface with first set of question details:
        GenerateQuestion();

        rend = lift.GetComponent<Renderer>();
        // Load materials array of lift game object into temporary array:
        materials = rend.materials;
        RenderLiftInactive();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<MCQAnswer>().isCorrect = false;
            // Text child components under each button:
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = qna[currentQuestion].options[i];
            if (qna[currentQuestion].correctOption == i)
            {
                // Only option at the correct index will be set to 'true'. This is declared within the inspector:
                 options[i].GetComponent<MCQAnswer>().isCorrect = true;
            }
        }
    }

    void GenerateQuestion()
    {
        if (qna.Count > 0)
        {
            // Retrieve question from question array if not empty:
            currentQuestion = Random.Range(0, qna.Count);
            // Display progress of quiz:
            questionNumberText.text = $"Q{currentQuestionNumber} of {totalQuestions}";
            // Display question text:
            questionText.text = qna[currentQuestion].question;
            // Populate answer options:
            SetAnswers();
        }
        else
        {
            // If no more questions to set, terminal is complete:
            isCompleted = true;
            CompletionScreen();
        }
       
    }

    public void AnswerCorrectly()
    {
        // Override message from any previously-incorrect answer:
        incorrectMessage.SetActive(false);
        // Remove correctly-answered question from the random selection process:
        qna.RemoveAt(currentQuestion);
        // Increment question progress:
        currentQuestionNumber ++;
        // If answered correctly, generate next question, if one still exists:
        GenerateQuestion();
    }

    public void AnswerIncorrectly()
    {
        // Impose time penalty if answered incorrectly:
        TimeManager.currentTime -= timePenalty;
        // Play incorrect answer sound effect:
        incorrectAnswerSFX.volume = VolumeManager.sfxVolume;
        incorrectAnswerSFX.Play();
        StartCoroutine(DisplayIncorrect());
    }

    IEnumerator DisplayIncorrect()
    {
        incorrectMessage.SetActive(true);
        // Display message for 3 seconds:
        yield return new WaitForSeconds(3);
        incorrectMessage.SetActive(false);
    }

    public void CompletionScreen()
    {
        // Close terminal MCQ interface:
        quizScreen.SetActive(false);
        // Activate completion screen:
        completionScreen.SetActive(true);
        // Change materials for inactive lift:
        RenderLiftActive();
    }

    void RenderLiftInactive()
    {
        x = 0;
        // Set lift lighting material to first optional material (emissive orange):
        materials[1] = optionmaterials[x];
        // Assign temporary materials array to current materials array:
        rend.materials = materials;
    }

    void RenderLiftActive()
    {
        // Change colour of lift:
        x = 1;
        // Set lift lighting material to second optional material (emissive blue):
        materials[1] = optionmaterials[x];
        // Assign temporary materials array to current materials array:
        rend.materials = materials;
    }
}
