
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleColumnBehavior : ColumnBehaviour
{
	public SimpleColumnBehavior()
	{
		length = 3;
	}

	void Start() {
		Transform cubeTransform = GetComponent<Transform>();
		if (cubeTransform == null)
		{
			Debug.LogError("Transform not found");
		}
		Vector3 positionDelta;
		Quaternion rotationDelta;

		positionDelta = new Vector3(0 * size, 0, 0);
		rotationDelta = Quaternion.Euler(0, 0, 0);
		Instantiate(slideCube, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		positionDelta = new Vector3(0, 1 * size, 0);
		rotationDelta = Quaternion.Euler(0, 0, 0);
		Instantiate(slideCube, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		positionDelta = new Vector3(0, 2 * size, 0);
		rotationDelta = Quaternion.Euler(90, 0, 0);
		Instantiate(flatCube, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
	}

	void Update()
	{
		
		//GetComponent<ColumnBehaviour>().Update();
		CheckKeys();
	}
}