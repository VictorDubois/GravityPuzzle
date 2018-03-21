using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardBehavior : MonoBehaviour {
	public float SpotDistance = 1;
	public int numberElX = 4;
	public int numberElY = 4;
	public GameObject face;

	// Use this for initialization
	void Start () {
		Transform thisTransform = GetComponent<Transform>();
		if (thisTransform == null)
		{
			Debug.LogError("Transform not found");
		}
		Quaternion rotation = Quaternion.Euler(180, 0, 0);
		Vector3 position = new Vector3(0, 0, 0);

		for(int i = -(numberElX-1)/2 ; i <= numberElX / 2; i++)
		{
			for (int j = -(numberElY - 1) / 2; j <= numberElY / 2; j++)
			{
				position = new Vector3(i, 0, j);
				Instantiate(face, thisTransform.position + position, thisTransform.rotation * rotation, thisTransform);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
