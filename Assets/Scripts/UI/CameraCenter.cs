using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCenter : MonoBehaviour
{
	public float rotationSpeed = 60f;
	public float ascentSpeed = 2f;

	//private Transform camTransform;
	// Use this for initialization
	void Start()
	{
		//camTransform = GetComponent<Transform>();
		//Debug.Log(camTransform.position.ToString());
	}

	// Update is called once per frame
	void Update()
	{
		UpdatePosition(rotationSpeed * Input.GetAxis("HorizontalCamera") * Time.deltaTime, ascentSpeed * Input.GetAxis("VerticalCamera") * Time.deltaTime);

		//if (Input.GetKey(KeyCode.Q))
		//{
		//	camTransform.RotateAround(rotateAround.position, Vector3.up, rotationSpeed * Time.deltaTime);//Vector3.zero
		//}
		//else if (Input.GetKey(KeyCode.D))
		//{
		//	camTransform.RotateAround(rotateAround.position, Vector3.up, -rotationSpeed * Time.deltaTime);//Vector3.zero
		//}
		//if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Z))
		//{
		//	camTransform.Translate(0.0f, ascentSpeed * Time.deltaTime, 0.0f);
		//}
		//else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		//{
		//	camTransform.Translate(0.0f, -ascentSpeed * Time.deltaTime, 0.0f);
		//}
	}

	void UpdatePosition(float rot, float up)
	{
		transform.Rotate(Vector3.up, rot);//Vector3.zero

		transform.Translate(0.0f, up, 0.0f);
	}

	public void Turn(float rot)
	{
		transform.SetPositionAndRotation(transform.position, Quaternion.Euler(transform.rotation.x, rot, transform.rotation.z));
	}

	public void Ascent(float height)
	{
		transform.SetPositionAndRotation(new Vector3(transform.position.x, height, transform.position.z), transform.rotation);
	}
}
