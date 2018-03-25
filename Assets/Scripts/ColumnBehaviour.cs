using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnBehaviour : MonoBehaviour {
	public Material columnColor;
	public Material colorToReplace;
	public bool fixedPosition;
	public bool lastPlaced;
	public bool upsideDown = false;
	public float size = 1.0f;

	public GameObject slideCube;
	public GameObject flatCube;
	private bool selected;
	private Vector3 initialPosition;
	protected int length;
	protected int offsetX = 0;
	protected int offsetZ = 0;

	protected Material[] materials;

	//private Transform transform;
	public ColumnBehaviour()
	{
	}

	public ColumnBehaviour (Material newColor, bool isFixedPosition)
	{
		columnColor = newColor;
		fixedPosition = isFixedPosition;
		lastPlaced = true;
	}

	public void Turn (bool left)
	{
		if (MouvmentAllowed())
		{
			if (left)
			{
				transform.Rotate(0, 90, 0, Space.Self);
			}
			else
			{
				transform.Rotate(0, -90, 0, Space.Self);
			}
		}
	}
	
	public void SwitchSide (bool force)
	{
		if (force || MouvmentAllowed())
		{
			GetComponent<Transform>().Rotate(180, 0, 0, Space.Self);
			GetComponent<Transform>().Translate(0, -size * (length - 1), 0, Space.Self);
		}
	}

	private bool MouvmentAllowed()
	{
		return IsSelected() && !fixedPosition;
	}

	// Use this for initialization
	void Start () {
	}

	protected void Init() {
		if (upsideDown)
		{
			SwitchSide(true);
		}

		Renderer[] renderers = GetComponentsInChildren<Renderer>();

		materials = new Material[renderers.Length];

		for (int i = 0; i< renderers.Length; i++)
		{
			materials.SetValue(renderers[i].material, i);
		}

		Color currentColor;
		Material currentMaterial;
		for (int i = 0; i < materials.Length; i++)
		{
			currentMaterial = materials[i];

			// Test if the color is the color to replace with the color of the column
			// Indeed, the color of the slide is to be replaced, but not the color of the frame (currently)
			if (currentMaterial.color == colorToReplace.color)
			{
				currentMaterial = columnColor;
			}
			currentColor = currentMaterial.color;

			materials[i].color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
		}

		if(fixedPosition)
		{
			for (int i = 0; i < materials.Length; i++)
			{
				currentColor = materials[i].color;
				float meanColor = (currentColor.r + currentColor.g + currentColor.b) / 3;
				materials[i].color = new Color((currentColor.r + meanColor)/2, (currentColor.g + meanColor) / 2, (currentColor.b + meanColor) / 2, 0.5f);
			}
		}
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void CheckKeys()
	{
		if (MouvmentAllowed())
		{
			//if (Input.GetKeyDown(KeyCode.Space))
			if (Input.GetButtonDown("ReverseColumn"))
			{
					SwitchSide(false);
			}
			//if (Input.GetKeyDown(KeyCode.LeftArrow))
			if (Input.GetButtonDown("TurnColumnLeft"))
			{
				Turn(true);
			}
			//if (Input.GetKeyDown(KeyCode.RightArrow))
			if (Input.GetButtonDown("TurnColumnRight"))
			{
				Turn(false);
			}

			if(Input.GetButtonDown("DeleteColumn"))
			{
				AskResetPosition();
			}
		}
	}

	public void Select()
	{
		Color currentColor;
		for (int i = 0; i < materials.Length; i++)
		{
			currentColor = materials[i].color;
			materials[i].color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.8f);
		}
		selected = true;
	}

	public void Deselect()
	{
		Color currentColor;
		for (int i = 0; i < materials.Length; i++)
		{
			currentColor = materials[i].color;
			materials[i].color = new Color(currentColor.r, currentColor.g, currentColor.b, 0.5f);
		}
		selected = false;
	}

	public bool IsSelected()
	{
		return selected;
	}

	public int GetLength()
	{
		return length;
	}

	public void SetInitialPosition(Vector3 newPosition)
	{
		initialPosition = newPosition;

		ResetPosition();
	}

	public void AskResetPosition()
	{
		if(selected)
		{
			ResetPosition();
		}
	}

	private void ResetPosition()
	{
		transform.SetPositionAndRotation(initialPosition, Quaternion.Euler(0, 0, 0));
	}

	private void OnDestroy()
	{
		for (int i = 0; i < materials.Length; i++)
		{
			Destroy(materials[i]);
		}
	}
}

