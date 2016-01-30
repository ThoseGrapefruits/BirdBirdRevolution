using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

	private TextMesh myText;

    // Use this for initialization
    void Start()
    {
		myText = this.GetComponent<TextMesh>();

		myText.text = "Game Over\nPress R to try again\nScore: " + PlayerController.score;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("Scenes/real_scene_pls_notice");
        }
    }
}
