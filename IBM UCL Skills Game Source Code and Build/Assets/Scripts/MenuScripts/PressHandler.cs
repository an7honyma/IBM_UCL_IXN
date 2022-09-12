using UnityEngine;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

/*
REFERENCES:
Hyperlink Project (BlackthornProd):
https://github.com/BlackthornProd/Hyperlink-project

*/

public class PressHandler : MonoBehaviour, IPointerDownHandler
{
	[Serializable]
	public class ButtonPressEvent : UnityEvent { } 

	public ButtonPressEvent OnPress = new ButtonPressEvent();

	public void OnPointerDown(PointerEventData eventData)
	{
		OnPress.Invoke();
	}
}