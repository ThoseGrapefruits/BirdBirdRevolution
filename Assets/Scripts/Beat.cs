using UnityEngine;
using System.Collections;

public class Beat : MonoBehaviour {

	public float WAIT_TIME;
	public float SHOW_TIME;
	private float timer;

	private int counter;

	public bool comboTime;

	[SerializeField] private AudioClip blip;
	private AudioSource sounds;

	// Use this for initialization
	void Start () {

		float[] randomBeat = generateRandomBeat();

		WAIT_TIME = randomBeat[0];
		SHOW_TIME = randomBeat[1];

		Debug.Log (randomBeat[0]);
		Debug.Log (randomBeat[1]);

		counter = 0;
		comboTime = false;

		StartCoroutine (Wait());

		sounds = this.GetComponent<AudioSource>();
		sounds.clip = blip;
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	IEnumerator Wait() {

		for (timer = WAIT_TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		this.GetComponent<SpriteRenderer>().enabled = true;
		comboTime = true;

		sounds.PlayOneShot (blip);

		counter++;

		StartCoroutine (Show ());

	}

	IEnumerator Show() {

		for (timer = SHOW_TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		this.GetComponent<SpriteRenderer>().enabled = false;
		comboTime = false;

		StartCoroutine (Wait ());

	}

	/* Randomly generate a 2-element array where the first element is the wait time and the second
	 * is the show time */
	private float[] generateRandomBeat() {

		WAIT_TIME = Random.Range (0.4f, 0.8f);
		SHOW_TIME = WAIT_TIME / 2;

		float[] result = {WAIT_TIME, SHOW_TIME};

		return result;

	}

}
