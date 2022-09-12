using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

public class TimerTests
{
    private GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/TestScenePrefab.prefab");

    [UnityTest]
    public IEnumerator CheckTimerDecrement()
    {
        var testScene = Object.Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
        Transform timer = testScene.transform.Find("Timer");
        yield return new WaitForSeconds(2f);
        float previousTime = TimeManager.currentTime;
        yield return new WaitForSeconds(2f);
        float currentTime = TimeManager.currentTime;
        
        if (Time.timeScale == 1 && timer.gameObject.activeSelf == true)
        {
            // If the game is unpaused and the timer is active, the timer will count down:
            Assert.IsTrue(currentTime <= previousTime);
        }
        if (Time.timeScale == 0 && timer.gameObject.activeSelf == true)
        {
            // If the game is paused and the timer is active, the timer will not count down:
            Assert.IsTrue(currentTime == previousTime);
        }
    }
}