using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class TutoBehavior : MonoBehaviour {

	public GameObject toBeToggled;

	private bool toggle = true;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		if (btn == null)
		{
			Debug.LogError("Button not found");
		}
		btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void TaskOnClick() {
		// Once every 2 actions, to dismiss onMouseUp
		toggle = !toggle;
		if (!toggle)
		{
			// Toggle displaying the tutorial
			toBeToggled.SetActive(!toBeToggled.activeSelf);
		}
	}
}
