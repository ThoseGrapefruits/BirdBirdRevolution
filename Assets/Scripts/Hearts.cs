using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	[SerializeField] private GameObject heart1;
	[SerializeField] private GameObject heart2;
	[SerializeField] private GameObject heart3;

	private SpriteRenderer render;

	private int lives;
	private GameObject[] heartList = new GameObject[3];

	// Use this for initialization
	void Start () {

		heartList[0] = heart1;
		heartList[1] = heart2;
		heartList[2] = heart3;

		lives = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
		


	}

	public void loseOneLife() {

		Destroy (heartList[lives--]);

	}
}
