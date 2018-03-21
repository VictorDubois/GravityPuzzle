using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishBehaviour : MonoBehaviour {
	public GameObject victoryDisplay;

	// Use this for initialization
	void Start () {
		//victoryDisplay.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			print("VICTORY!!!!!!!!!!!!!!!!!!!!!!!!!");

			int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

			// Is the current scene the last one ? (0-indexed)
			if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
			{
				// End of game, victory
				Instantiate(victoryDisplay);
				// Destroy ball, as it would otherwise glitch through the end cube
				Destroy(other.gameObject);
			}
			else
			{
				// Load next level
				SceneManager.LoadScene(currentSceneIndex + 1, LoadSceneMode.Single);
			}
		}
	}
}
