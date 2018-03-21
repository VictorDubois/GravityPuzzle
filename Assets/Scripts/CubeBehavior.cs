using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour {
	public GameObject Face;
	public float size = 0.5f;

	// Use this for initialization
	void Start () {
		Transform cubeTransform= GetComponent<Transform>();
		if (cubeTransform == null)
		{
			Debug.LogError("Transform not found");
		}
		Vector3 positionDelta;
		Quaternion rotationDelta;
		// Instantiate all faces

		positionDelta = new Vector3(size, 0, 0);//cubeTransform.position.x + 
		rotationDelta = Quaternion.Euler(0, -90, 0);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

		positionDelta = new Vector3(0, size, 0);
		rotationDelta = Quaternion.Euler(90, 0, 0);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

		positionDelta = new Vector3(0, 0, size);
		rotationDelta = Quaternion.Euler(0, 180, 0);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

		positionDelta = new Vector3(-size, 0, 0);
		rotationDelta = Quaternion.Euler(0, 90, 0);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

		positionDelta = new Vector3(0, -size, 0);
		rotationDelta = Quaternion.Euler(-90, 0, 0);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

		positionDelta = new Vector3(0, 0, -size);
		rotationDelta = Quaternion.Euler(0, 0, 90);
		//Instantiate(Face, cubeTransform.position + positionDelta, cubeTransform.rotation * rotationDelta, cubeTransform);
		Instantiate(Face, cubeTransform.position + positionDelta, rotationDelta, cubeTransform);

	}

	// Update is called once per frame
	void Update () {
		
	}
}
