using UnityEngine;

/*
REFERENCES:
How to Make a Quiz Game with Multiple Choices in Unity (Youtube/The Game Guy):
https://www.youtube.com/watch?v=G9QDFB2RQGA
How to Make a Quiz Game with Multiple Choices in Unity | Part 2 (Youtube/The Game Guy):
https://www.youtube.com/watch?v=POUemIGCyr0
*/

public class MCQAnswer : MonoBehaviour
{
    public bool isCorrect = false;
    public MCQManager mcqManager;

    public void Answer()
    {
        // If answer is correct:
        if (isCorrect)
        {
            mcqManager.AnswerCorrectly();
        }
        // If answer is incorrect:
        else
        {
            mcqManager.AnswerIncorrectly();
        }
    }
}
