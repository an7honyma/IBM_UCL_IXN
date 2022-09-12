using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.UI;

/*
REFERENCES:
Hyperlink Project (BlackthornProd):
https://github.com/BlackthornProd/Hyperlink-project

*/

public class Link : MonoBehaviour 
{
	// Situated in main menu scene:
	public void OpenCloudJourney()
	{
		#if !UNITY_EDITOR
		openWindow("https://prezi.com/view/KAWYBQv8iyGTgy4oiJQj/");
		#endif
	}

	// Situated in main menu scene:
	public void OpenRegistrationPage()
	{
		#if !UNITY_EDITOR
		openWindow("https://www.ibm.com/academic/home");
		#endif
	}

	// Game level topic resource buttons:

	public void OpenLevelOneURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://keyskill-clms.comprehend.ibm.com/course/view.php?id=233");
		#endif
	}

	public void OpenLevelTwoURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/mod/page/view.php?id=51609");
		#endif
	}

	public void OpenLevelThreeURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/course/view.php?id=4483");
		#endif
	}

	public void OpenLevelFourURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/course/view.php?id=8380");
		#endif
	}

	public void OpenLevelFiveURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://keyskill-clms.comprehend.ibm.com/course/view.php?id=386");
		#endif
	}

	public void OpenLevelSixURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/course/view.php?id=8373");
		#endif
	}

	public void OpenLevelSevenURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/course/view.php?id=8382");
		#endif
	}

	public void OpenLevelEightURL()
	{
		#if !UNITY_EDITOR
		openWindow("https://learn.ibm.com/course/view.php?id=4482");
		#endif
	}

	[DllImport("__Internal")]
	private static extern void openWindow(string url);

}