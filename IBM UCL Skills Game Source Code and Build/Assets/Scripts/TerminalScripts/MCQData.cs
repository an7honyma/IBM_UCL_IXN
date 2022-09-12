/*
REFERENCES:
How to Make a Quiz Game with Multiple Choices in Unity (Youtube/The Game Guy):
https://www.youtube.com/watch?v=G9QDFB2RQGA
How to Make a Quiz Game with Multiple Choices in Unity | Part 2 (Youtube/The Game Guy):
https://www.youtube.com/watch?v=POUemIGCyr0

*/

[System.Serializable]

public class MCQData
{
   // Data for each question in a level quiz:
   // Question text:
   public string question;
   // Array of answer options:
   public string[] options;
   // Index of correct option:
   public int correctOption;
}
