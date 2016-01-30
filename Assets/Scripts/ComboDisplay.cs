using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ComboDisplay : MonoBehaviour {

	// Keep a reference to the burd
	[SerializeField] private GameObject theBird;

	private Text textComp = this.GetComponent<Text>();
	private PlayerController playerComp = theBird.GetComponent<PlayerController>();

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		textComp.text = playerComp.GetActiveCombo();
	
	}
}
