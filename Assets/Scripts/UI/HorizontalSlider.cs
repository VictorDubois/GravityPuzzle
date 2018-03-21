using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class HorizontalSlider : Selectable
{
	public Slider mainSlider;
	private CameraCenter myCamera;

	private void Start()
	{
		if (mainSlider == null)
		{
			mainSlider = GetComponent<Slider>();
		}
		if (mainSlider == null)
		{
			Debug.LogError("Horizontal Slider not found!");
		}

		myCamera = FindObjectOfType<CameraCenter>();
		if (myCamera == null)
		{
			Debug.LogError("CameraCenter not found!");
		}
	}

	//Invoked when a submit button is clicked.
	private void Update()
	{
		if (IsPressed())
		{
			myCamera.Turn(mainSlider.value);
		}
	}
}