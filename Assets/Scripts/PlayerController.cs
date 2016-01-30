using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Store an instance of a beat object
    [SerializeField]
    private GameObject theBeat;

	[SerializeField] private GameObject flyText;

    [SerializeField]
    private GameObject ladyBirdComp;
    private LadyBirdController ladyBird;

    // Constants
    private const float POINTS_PER_MOVE = 3f;
    private const float ON_BEAT_MULT = 2f;
    private const int MAX_COMBO_SIZE = 3;

    // Glob variables
    public int score;

    private enum Move
    {
        U = 'U', D = 'D', L = 'L', R = 'R'
    };

    private enum ComboState
    {
        sat, unsat, failed
    };

    public SortedDictionary<string, string> combos = new SortedDictionary<string, string>();
    private string activeCombo = "";

    void Start()
    {
        combos.Add("Twirl", "LRL");
        combos.Add("Wavedash Right", "RRD");
        combos.Add("Wavedash Left", "LLD");
        combos.Add("Split", "DDD");
        combos.Add("Jump Split", "UUD");
        combos.Add("Flip Right", "URD");
        combos.Add("Flip Left", "ULD");

        // Duh, count your current score
        score = 0;

        ladyBird = ladyBirdComp.GetComponent<LadyBirdController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Up"))
        {
            AddMove(Move.U);
        }
        if (Input.GetButtonDown("Down"))
        {
            AddMove(Move.D);
        }
        if (Input.GetButtonDown("Left"))
        {
            AddMove(Move.L);
        }
        if (Input.GetButtonDown("Right"))
        {
            AddMove(Move.R);
        }

        CheckForCombo();
    }

    private void AddMove(Move move)
    {
        activeCombo += move;
        if (!CheckForCombo() && activeCombo.Length >= MAX_COMBO_SIZE)
        {
            ladyBird.CompleteCombo(activeCombo); // Lady bird won't be happy
			InstantiateComboText(ComboState.failed, activeCombo); // Make combo text
            ClearCombo();
        }
    }

    private bool CheckForCombo()
    {
        foreach (string combo in combos.Values)
        {
            // If this combo matches the active combo
            if (combo.Equals(activeCombo))
            {
                CompleteCombo(combo); // We made it boys
                return true;
            }
        }
        return false;
    }

    private void CompleteCombo(string combo)
    {
        AddScoreFor(combo);
        InstantiateComboText(ladyBird.CompleteCombo(combo) ? ComboState.sat : ComboState.unsat, combo); // Make combo text
        ClearCombo();
    }

    private void AddScoreFor(string combo)
    {
        float scoreIncr = combo.Length * POINTS_PER_MOVE;
        if (theBeat.GetComponent<Beat>().comboTime)
        {
            scoreIncr *= ON_BEAT_MULT;
        }
        score += (int)scoreIncr;
    }

	private void InstantiateComboText(ComboState comboState, string combo)
    {

		Debug.Log(comboState);

		Color toPass = Color.white;

		// Figure out what color the text will be
		switch (comboState) {
		case ComboState.sat:
			toPass = Color.green;
			break;

		case ComboState.failed:
			toPass = Color.red;
			break;

		case ComboState.unsat:
			toPass = Color.red;
			break;
		}

		Instantiate(flyText);
		flyText.GetComponent<FlyingText>().init();
		flyText.GetComponent<FlyingText>().setText(combo, toPass);

    }

    private void ClearCombo()
    {
        activeCombo = "";
    }

    public string GetActiveCombo()
    {
        return activeCombo;
    }
}
