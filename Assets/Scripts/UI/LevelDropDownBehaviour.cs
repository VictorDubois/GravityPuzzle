using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelDropDownBehaviour : MonoBehaviour {

	private Dropdown levelDropdown;

	// Use this for initialization
	void Start () {
		int sceneCount = SceneManager.sceneCountInBuildSettings;
		levelDropdown = GetComponent<Dropdown>();

		//List<string> levelList = new List<string>();
		//for(int i = 0; i < sceneCount; i++)
		//{
		//	Scene scene = SceneManager.GetSceneByBuildIndex(i);
		//	//Scene currentScene = SceneManager.GetSceneAt(i);
		//	levelList.Add(scene.path);
		//	Debug.Log(scene.ToString());
		//	Debug.Log(scene.path);
		//}

		//Debug.Log(levelList.ToString());
		//levelDropdown.AddOptions(levelList);

		levelDropdown.onValueChanged.AddListener(OnValueChanged);
	}

	void OnValueChanged(int selection)
	{
		SceneManager.LoadScene(selection, LoadSceneMode.Single);

		//string sceneName =  levelDropdown.options[selection].text;
		//Scene newActiveScene = SceneManager.GetSceneByName(sceneName);
		//Debug.Log(sceneName);

		//if (newActiveScene == null)
		//{
		//	throw new UnityException("Scene not found, is the list OK?");
		//}

		//Debug.Log(newActiveScene);
		//SceneManager.SetActiveScene(newActiveScene);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}
