using UnityEngine;
using System.Collections;

public class Pulse : MonoBehaviour {
	
	[SerializeField] private GameObject block;

	private GameObject[] blocks = new GameObject[4];

	private float GROW_SPEED = 0.05f;

	private bool done;

	private Beat myBeat;

	private int timeToLive;

	// Use this for initialization
	void Start () {

		for (int i = 0; i < 4; i++) {
			blocks[i] = Instantiate(block);
		}

		initBlocks();

		done = false;

		myBeat = this.GetComponent<Beat>();

		timeToLive = 5;

		StartCoroutine(timeUntilDeath());
	
	}
	
	// Update is called once per frame
	void Update () {

		if (!done) grow();
		else {
			for (int i = 0; i < 4; i++) {
				Destroy(blocks[i].gameObject);
			}
			Destroy(this.gameObject);
		}
	
	}

	private void moveBlock(Vector2 newPos, GameObject block) {

		block.transform.position = newPos;

	}
				

	private void initBlocks() {

		Vector2 myPos = transform.position;
		Vector2 plug = Vector2.zero;

		Vector2 sides = new Vector2 (0.03f, 0.4f);
		Vector2 horiz = new Vector2 (0.4f, 0.03f);

		plug.x = myPos.x;
		plug.y = myPos.y + 0.1f;
		moveBlock(plug, blocks[0]);
		blocks[0].transform.localScale = horiz;

		plug.x = myPos.x + 0.1f;
		plug.y = myPos.y;
		moveBlock(plug, blocks[1]);
		blocks[1].transform.localScale = sides;

		plug.x = myPos.x;
		plug.y = myPos.y - 0.1f;
		moveBlock(plug, blocks[2]);
		blocks[2].transform.localScale = horiz;

		plug.x = myPos.x - 0.1f;
		plug.y = myPos.y;
		moveBlock(plug, blocks[3]);
		blocks[3].transform.localScale = sides;

	}

	public void grow() {

		Vector2 temp = blocks[0].transform.position;
		temp.y += GROW_SPEED;
		blocks[0].transform.position = temp;

		temp = blocks[0].transform.localScale;
		temp.x += (3 * GROW_SPEED);
		blocks[0].transform.localScale = temp;

		/* ---- */

		temp = blocks[1].transform.position;
		temp.x += GROW_SPEED;
		blocks[1].transform.position = temp;

		temp = blocks[1].transform.localScale;
		temp.y += (3 * GROW_SPEED);
		blocks[1].transform.localScale = temp;

		/* ---- */

		temp = blocks[2].transform.position;
		temp.y -= GROW_SPEED;
		blocks[2].transform.position = temp;

		temp = blocks[2].transform.localScale;
		temp.x += (3 * GROW_SPEED);
		blocks[2].transform.localScale = temp;

		/* ---- */

		temp = blocks[3].transform.position;
		temp.x -= GROW_SPEED;
		blocks[3].transform.position = temp;

		temp = blocks[3].transform.localScale;
		temp.y += 3 * GROW_SPEED;
		blocks[3].transform.localScale = temp;


	}

	IEnumerator timeUntilDeath() {

		for (float i = 0; i < timeToLive; i += Time.deltaTime) {
			yield return 0;
		}

		done = true;

	}

}
