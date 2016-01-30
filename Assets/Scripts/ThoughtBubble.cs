using UnityEngine;
using System.Collections;

public class ThoughtBubble : MonoBehaviour {

	[SerializeField] private GameObject ladyBird;
	private LadyBirdController ladyBirdCont;
	private TextMesh myText;

	// Use this for initialization
	void Start () {

		ladyBirdCont = ladyBird.GetComponent<LadyBirdController>();
		myText = this.GetComponent<TextMesh>();
	
	}
	
	// Update is called once per frame
	void Update () {

		myText.text = ladyBirdCont.GetDesiredCombo();
	
	}
}
