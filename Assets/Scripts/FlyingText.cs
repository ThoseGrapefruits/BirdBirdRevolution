using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour {

	public string myString;

	public float FADE_SPEED = 0.1f;
	public float FLY_SPEED = 0.001f;

	private Rigidbody2D myRigidbody;
	private TextMesh myText;

	// Use this for initialization
	void Start () {

		myRigidbody = this.GetComponent<Rigidbody2D>();
		myText = this.GetComponent<TextMesh>();

		myText.text = myString;

		Vector2 myVel = myRigidbody.velocity;
		myVel.y = FLY_SPEED;
		myRigidbody.velocity = myVel;
	
	}
	
	// Update is called once per frame
	void Update () {

		Color temp = myText.color;
		temp.a -= 0.01f;
		myText.color = temp;
	
	}

	public void setText(string toSet, Color newColor) {

		myString = toSet;

	}
}
