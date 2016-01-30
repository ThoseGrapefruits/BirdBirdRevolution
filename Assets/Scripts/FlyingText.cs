using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour {

	public string myString;

	public float FADE_SPEED;
	public float FLY_SPEED;

	private TextMesh myText;

	private Vector3 myPos;

	// Use this for initialization
	void Start () {

		myText = this.GetComponent<TextMesh>();

		myText.text = myString;
	
	}
	
	// Update is called once per frame
	void Update () {

		myPos = transform.position;
		myPos.y += FLY_SPEED;
		transform.position = myPos;

		Color temp = myText.color;
		temp.a -= FADE_SPEED;
		myText.color = temp;
	
	}

	public void init() {

		myText = this.GetComponent<TextMesh>();

		myText.text = myString;

	}

	public void setText(string toSet, Color newColor) {

		myString = toSet;

		myText.color = newColor;

	}
}
