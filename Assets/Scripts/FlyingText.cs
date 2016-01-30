using UnityEngine;
using System.Collections;

public class FlyingText : MonoBehaviour {

	public float FADE_SPEED;
	public float FLY_SPEED;

	private TextMesh myText;

	private Vector3 myPos;

	// Use this for initialization
	void Start () {
		myText = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {

		myPos = transform.position;
		myPos.y += FLY_SPEED;
		transform.position = myPos;

		Color temp = myText.color;
		temp.a -= FADE_SPEED;
		myText.color = temp;

        if(temp.a <= 0)
        {
            Destroy(gameObject);
        }
	}

	public void init() {
		myText = GetComponent<TextMesh>();
	}

	public void setText(string toSet, Color newColor) {
		myText.text = toSet;
		myText.color = newColor;
	}
}
