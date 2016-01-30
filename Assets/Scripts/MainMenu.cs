using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("s")) {
			SceneManager.LoadScene("Scenes/real_scene_pls_notice");
		} else if (Input.GetKey("c")) {
			SceneManager.LoadScene("Scenes/combo_list");
		}
	
	}
}
