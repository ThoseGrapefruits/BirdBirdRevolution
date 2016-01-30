using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ComboListMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey("b")) {
			SceneManager.LoadScene("Scenes/Main_Menu");
		}
	
	}
}
