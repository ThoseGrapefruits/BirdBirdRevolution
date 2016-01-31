using UnityEngine;
using System.Collections;

public class Beat : MonoBehaviour {

	private float WAIT_TIME;
	private float SHOW_TIME;

	public float LOW_THRESHOLD;
	public float HI_THRESHOLD;

	private float timer;

	public bool comboTime;

	[SerializeField] private AudioClip blip;
	private AudioSource sounds;

	[SerializeField] private GameObject pulsator;

	// Use this for initialization
	void Start () {

		generateRandomBeat();

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

		comboTime = true;

		sounds.PlayOneShot (blip);

		Instantiate(pulsator);

		StartCoroutine (Show ());

	}

	IEnumerator Show() {

		for (timer = SHOW_TIME; timer >= 0; timer -= Time.deltaTime) {
			yield return 0;
		}

		comboTime = false;

		StartCoroutine (Wait ());

	}

	/* Randomly generate a 2-element array where the first element is the wait time and the second
	 * is the show time */
	private void generateRandomBeat() {

		WAIT_TIME = Random.Range (LOW_THRESHOLD, HI_THRESHOLD);
		SHOW_TIME = WAIT_TIME / 2;

	}

}
