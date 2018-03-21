using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ButtonCleaner : MonoBehaviour {
	public Button myButton;

	private ColumnManagerBehavior columnManager;
	private SelectFace gameController;
	private BallGeneration ballGenerator;

	private bool toggleTurnLeft;
	private bool toggleTurnRight;
	private bool toggleInvert;
	private bool togglePlaceSelect;
	private bool toggleStartButton;

	void Start()
	{
		toggleTurnLeft = true;
		toggleTurnRight = true;
		toggleInvert = true;
		toggleStartButton = true;
		columnManager = FindObjectOfType<ColumnManagerBehavior>();
		gameController = FindObjectOfType<SelectFace>();
		ballGenerator = FindObjectOfType<BallGeneration>();
		Button btn;
		if (myButton == null)
		{
			btn = GetComponent<Button>();
		}
		else
		{
			btn = myButton;
		}
		
		//Debug.Log("btn.name = " + btn.name.ToString());
		if (btn.name == "TurnLeft")
		{
			btn.onClick.AddListener(TurnLeft);
		}
		else if (btn.name == "TurnRight")
		{
			btn.onClick.AddListener(TurnRight);
		}
		else if (btn.name == "Invert")
		{
			btn.onClick.AddListener(Invert);
		}
		else if (btn.name == "PlaceColumn")
		{
			btn.onClick.AddListener(PlaceSelect);
		}
		else if (btn.name == "Start")
		{
			btn.onClick.AddListener(StartButton);
		}
	}

	void TurnLeft()
	{
		toggleTurnLeft = !toggleTurnLeft;
		if (!toggleTurnLeft)
		{
			columnManager.Turn(true);
		}
	}

	void TurnRight()
	{
		toggleTurnRight = !toggleTurnRight;
		if (!toggleTurnRight)
		{
			columnManager.Turn(false);
		}
	}

	void Invert()
	{
		toggleInvert = !toggleInvert;
		if (!toggleInvert)
		{
			columnManager.Invert();
		}
	}

	void PlaceSelect()
	{
		togglePlaceSelect = !togglePlaceSelect;
		if (!togglePlaceSelect)
		{
			gameController.ToggleLeftClickPlacement();
		}
	}

	void StartButton()
	{
		toggleStartButton = !toggleStartButton;
		if (!toggleStartButton)
		{
			ballGenerator.NewBall();
		}
	}
}
