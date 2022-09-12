using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class TerminalTests
{
    private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScenePrefab.prefab");

    [UnityTest]
    public IEnumerator CheckTerminalMaterials()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform terminal = testScene.transform.Find("Terminal");

        yield return new WaitForSeconds(1f);
        
        if (terminal.gameObject.GetComponent<CheckPlayerRange>().inRange)
        {
            // If the player is in range of the terminal, the emission colour should change:
            Assert.IsTrue(terminal.GetComponent<CheckPlayerRange>().materials[1] == terminal.GetComponent<CheckPlayerRange>().optionmaterials[1]);
        }
        else if (!terminal.gameObject.GetComponent<CheckPlayerRange>().inRange)
        {
            Assert.IsTrue(terminal.GetComponent<CheckPlayerRange>().materials[1] == terminal.GetComponent<CheckPlayerRange>().optionmaterials[0]);
        }
    }

    [UnityTest]
    public IEnumerator CheckVisualPrompt()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform terminal = testScene.transform.Find("Terminal");
        Transform glowingE = terminal.Find("GlowingE");
        Transform mcqManager = testScene.transform.Find("MCQManager");

        yield return new WaitForSeconds(1f);
        
        if (mcqManager.gameObject.GetComponent<MCQManager>().isCompleted)
        {
            // If all questions are completed for the level, the visual prompt above the terminal will stop rendering:
            Assert.IsTrue(glowingE.gameObject.activeSelf == false);
        }
        else
        {
            // Else, the visual prompt will continue to render:
            Assert.IsTrue(glowingE.gameObject.activeSelf == true);
        }
    }

    [UnityTest]
    public IEnumerator CheckAnswerQuestionCorrectly()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform mcqManager = testScene.transform.Find("MCQManager");
        int previousCount = mcqManager.gameObject.GetComponent<MCQManager>().qna.Count;

        yield return new WaitForSeconds(1f);
        
        mcqManager.gameObject.GetComponent<MCQManager>().AnswerCorrectly();

        yield return new WaitForSeconds(1f);

        // If a question is answered correctly, the number of questions left to be answered will decrement by one:
        Assert.IsTrue(mcqManager.gameObject.GetComponent<MCQManager>().qna.Count < previousCount);
    }

    [UnityTest]
    public IEnumerator CheckAnswerQuestionIncorrectly()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform mcqManager = testScene.transform.Find("MCQManager");
        int previousCount = mcqManager.gameObject.GetComponent<MCQManager>().qna.Count;

        yield return new WaitForSeconds(1f);

        float previousTime = TimeManager.currentTime;
        mcqManager.gameObject.GetComponent<MCQManager>().AnswerIncorrectly();
        float currentTime = TimeManager.currentTime;

        yield return new WaitForSeconds(1f);
        Debug.Log(previousTime);
        Debug.Log(currentTime);
        // If a question is answered incorrectly, the number of questions left to be answered will stay the same:
        Assert.IsTrue(mcqManager.gameObject.GetComponent<MCQManager>().qna.Count == previousCount);
        Assert.IsTrue(currentTime <= previousTime - 60f);
    }

    [UnityTest]
    public IEnumerator CheckTerminalCompletion()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform mcqManager = testScene.transform.Find("MCQManager");
        Transform canvas = testScene.transform.Find("Canvas");
        Transform completionScreen = canvas.Find("CompletionScreen");

        yield return new WaitForSeconds(1f);
        
        if (completionScreen.gameObject.activeSelf == true)
        {
            // If completion appears on screen, the level's quiz is complete:
            Assert.IsTrue(mcqManager.gameObject.GetComponent<MCQManager>().isCompleted == true);
        }
    }
}