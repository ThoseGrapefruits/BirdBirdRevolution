using UnityEngine;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Store an instance of a beat object
    [SerializeField]
    private GameObject theBeat;

    [SerializeField]
    private GameObject ladyBirdComp;
    private LadyBirdController ladyBird;

    // Constants
    private const float POINTS_PER_MOVE = 3f;
    private const float ON_BEAT_MULT = 2f;
    private const int MAX_COMBO_SIZE = 4;

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
        combos.Add("Twirl", "LRLR");
        combos.Add("Wavedash Right", "RRD");
        combos.Add("Wavedash Left", "LLD");
        combos.Add("Split", "DD");
        combos.Add("Jump Split", "UUD");
        combos.Add("Flip Right", "UURD");
        combos.Add("Flip Left", "UULD");

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
            InstantiateComboText(ComboState.failed); // Make combo text
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
        InstantiateComboText(ladyBird.CompleteCombo(combo) ? ComboState.sat : ComboState.unsat); // Make combo text
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

    private void InstantiateComboText(ComboState comboState)
    {
        // JACK DO THIS
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
