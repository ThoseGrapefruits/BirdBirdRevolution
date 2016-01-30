using UnityEngine;
using System.Collections;

public class Beat : MonoBehaviour {

	private float TIME;
	private float timer;

	// Use this for initialization
	void Start () {

		TIME = 3;
	
	}
	
	// Update is called once per frame
	void Update () {

		StartCoroutine (Countdown());
	
	}

	IEnumerator Countdown() {

		for (timer = TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		Debug.Log ("derpderpderp");

	}
}
