using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGeneration : MonoBehaviour {
	public GameObject ball;
	public Transform startingPosition;

	private GameObject currentBall;

	// Use this for initialization
	void Start () {
		if(startingPosition ==null)
		{
			startingPosition = GetComponent<Transform>();
		}

		if (startingPosition == null)
		{
			Debug.LogError("Transform not found");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("RestartBall"))
		{
			NewBall();
		}
	}

	public void NewBall()
	{
		if(currentBall != null)
		{
			Destroy(currentBall);
		}
		currentBall = Instantiate(ball, startingPosition);
	}
}
