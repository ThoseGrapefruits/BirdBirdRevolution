using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {

	[SerializeField] private GameObject thePlayer;

	private PlayerController p;

	// Use this for initialization
	void Start () {

		p = thePlayer.GetComponent<PlayerController>();
	
	}
	
	// Update is called once per frame
	void Update () {

		this.GetComponent<TextMesh>().text = p.score.ToString();
	
	}
}
