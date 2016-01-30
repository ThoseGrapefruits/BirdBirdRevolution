using UnityEngine;
using System.Collections;

public class Hearts : MonoBehaviour {

	[SerializeField] private GameObject ladyBird;
	private LadyBirdController lbController;

	[SerializeField] private GameObject heart1;
	[SerializeField] private GameObject heart2;
	[SerializeField] private GameObject heart3;

	private SpriteRenderer render;

	private int lives;
	private GameObject[] heartList = new GameObject[3];

	// Use this for initialization
	void Start () {

		lbController = ladyBird.GetComponent<LadyBirdController>();

		heartList[0] = heart1;
		heartList[1] = heart2;
		heartList[2] = heart3;

		lives = 2;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		for (int i = 0; i < lives; i++) {

			render = heartList[i].GetComponent<SpriteRenderer>();
			render.enabled = true;

		}

		for (int i = lives; i < 2; i++) {

			render = heartList[i].GetComponent<SpriteRenderer>();
			render.enabled = false;

		}

	}

	public void loseOneLife() {

		lives--;

	}
}
