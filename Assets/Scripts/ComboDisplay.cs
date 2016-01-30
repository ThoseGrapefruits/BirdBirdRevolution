using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboDisplay : MonoBehaviour {

	// Keep a reference to the burd
	[SerializeField] private GameObject theBird;

	private TextMesh textComp;
	private PlayerController playerComp;
	private Transform theBirdTrans;

	// Use this for initialization
	void Start () {
	
		textComp = GetComponent<TextMesh>();
		playerComp = theBird.GetComponent<PlayerController>();
		theBirdTrans = theBird.GetComponent<Transform>();

	}
	
	// Update is called once per frame
	void Update () {

		textComp.text = playerComp.GetActiveCombo();


	
	}
}
