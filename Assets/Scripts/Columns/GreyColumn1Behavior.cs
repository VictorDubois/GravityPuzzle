using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyColumn1Behavior : ColumnBehaviour
{
	public GreyColumn1Behavior()
	{
		length = 1;
	}

	void Start()
	{
		Transform cubeTransform = GetComponent<Transform>();
		if (cubeTransform == null)
		{
			Debug.LogError("Transform not found");
		}
		Vector3 positionDelta;
		Quaternion rotationDelta;

		positionDelta = new Vector3(offsetX, 0 * size, offsetZ);
		rotationDelta = Quaternion.Euler(0, 0, 0);
		Instantiate(slideCube, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);

		Init();
	}

	void Update()
	{

		//GetComponent<ColumnBehaviour>().Update();
		CheckKeys();
	}
}
