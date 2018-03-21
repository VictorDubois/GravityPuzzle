using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class VerticalSlider : Selectable
{
	public Slider mainSlider;

	private RotateCam myCamera;

	private void Start()
	{
		if (mainSlider == null)
		{
			mainSlider = GetComponent<Slider>();
		}
		if (mainSlider == null)
		{
			Debug.LogError("Vertical Slider not found!");
		}

		myCamera = FindObjectOfType<RotateCam>();
		if (myCamera == null)
		{
			Debug.LogError("Camera not found!");
		}
	}

	//Invoked when a submit button is clicked.
	private void Update()
	{
		if (IsPressed())
		{
			myCamera.Ascent(mainSlider.value);
		}
	}
}