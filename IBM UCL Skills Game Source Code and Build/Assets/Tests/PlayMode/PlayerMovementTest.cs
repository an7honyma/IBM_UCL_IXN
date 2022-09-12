using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class PlayerMovementTest
{
    private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScenePrefab.prefab");

    [UnityTest]
    public IEnumerator CheckPlayerTerminalInteraction()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform terminal = testScene.transform.Find("Terminal");
        Transform player = testScene.transform.Find("Avatar");

        yield return new WaitForSeconds(1f);
        
        if (terminal.gameObject.GetComponent<CheckPlayerRange>().isInteracting)
        {
            // If the player is interacting with the terminal, the avatar's movement script is disabled:
            Assert.IsTrue(player.GetComponent<PlayerMovement>().enabled == false);
        }
    }

    [UnityTest]
    public IEnumerator CheckPlayerMovement()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform player = testScene.transform.Find("Avatar");
        Vector3 previousPosition = player.position;

        yield return new WaitForSeconds(1f);

        Vector3 currentPosition = player.position;

        yield return new WaitForSeconds(1f);
        
        if (previousPosition != currentPosition)
        {
            // If the player's avatar is changing position, the game is not paused:
            Assert.IsTrue(Time.timeScale == 1f);
        }
    }
}