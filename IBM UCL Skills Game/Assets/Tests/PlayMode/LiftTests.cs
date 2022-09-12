using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class LiftTests
{
    private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScenePrefab.prefab");

    [UnityTest]
    public IEnumerator CheckLiftMaterials()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform lift = testScene.transform.Find("Inactive_Lift");
        Transform mcqManager = testScene.transform.Find("MCQManager");
        Transform canvas = testScene.transform.Find("Canvas");
        Transform completionScreen = canvas.transform.Find("CompletionScreen");

        Material previousMaterial = lift.GetComponent<Renderer>().materials[1];

        mcqManager.GetComponent<MCQManager>().CompletionScreen();

        Material newMaterial = lift.GetComponent<Renderer>().materials[1];

        yield return new WaitForSeconds(1f);

        // If the completion screen appears on screen, the emission colour on the list should change:
        Assert.IsTrue(previousMaterial != newMaterial);
    }

    [UnityTest]
    public IEnumerator CheckLiftVisualPrompt()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform lift = testScene.transform.Find("Inactive_Lift");
        Transform visualPrompt = lift.Find("GlowingE");
        Transform mcqManager = testScene.transform.Find("MCQManager");

        yield return new WaitForSeconds(1f);

        if (mcqManager.GetComponent<MCQManager>().isCompleted == true)
        {
            // If the level quiz is completed, the visual prompt will show:
            Assert.IsTrue(visualPrompt.gameObject.activeSelf == true);
        }
        else if (mcqManager.GetComponent<MCQManager>().isCompleted == false)
        {
            // If the level quiz is not completed, the visual prompt will not show:
            Assert.IsTrue(visualPrompt.gameObject.activeSelf == false);
        }
    }
}