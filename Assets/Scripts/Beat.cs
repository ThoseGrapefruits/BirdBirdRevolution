using UnityEngine;
using System.Collections;

public class Beat : MonoBehaviour {

	public float WAIT_TIME;
	public float SHOW_TIME;
	private float timer;

	private int counter;

	// Use this for initialization
	void Start () {

//		WAIT_TIME = 0.5f;
//		SHOW_TIME = 0.5f;
		counter = 0;

		StartCoroutine (Wait());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Wait() {

		for (timer = WAIT_TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		this.GetComponent<SpriteRenderer>().enabled = true;

		counter++;
		Debug.Log (counter);

		StartCoroutine (Show ());

	}

	IEnumerator Show() {

		for (timer = SHOW_TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		this.GetComponent<SpriteRenderer>().enabled = false;

		StartCoroutine (Wait ());

	}
}
